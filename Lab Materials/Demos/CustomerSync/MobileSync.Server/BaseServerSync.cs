using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using MobileSync.Models;

namespace MobileSync.Server
{
    /// <summary>
    /// Co-ordinates the activities required for synchronising details from a mobile app to a server
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class BaseServerSync<T> where T : SyncObject
    {
        SyncResult<T> result = new SyncResult<T>();
        readonly List<ConflictItem<T>> conflicts = new List<ConflictItem<T>>();

        /// <summary>
        /// Gets the current in-user version from the database. This is used in order to compare and check for conflict errors
        /// when uploading new results from the database
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public virtual T GetItem(T item)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Inserts an item into the local database
        /// </summary>
        /// <param name="item"></param>
        public virtual int Insert(T item)
        {
			throw new NotImplementedException();
        }

        /// <summary>
        /// Updates an existing entry in the database
        /// </summary>
        /// <param name="item"></param>
        public virtual void Update(T item)
        {

        }

        /// <summary>
        /// Deletes an entry in the database
        /// </summary>
        /// <param name="item"></param>
        public virtual void Delete(T item)
        {

        }

        /// <summary>
        /// Makes a log of an action that occurred if required
        /// </summary>
        /// <param name="action"></param>
        /// <param name="item"></param>
        public virtual void Audit(AuditAction action, T item)
        {
            
        }

        /// <summary>
        /// Initialization code. Useful if you want to apply all operations within a transaction and need to create the 
        /// transaction object
        /// </summary>
        protected virtual void Setup()
        {

        }

        /// <summary>
        /// Commit the changes that were made to the database
        /// </summary>
        protected virtual void Commit()
        {
            
        }

        /// <summary>
        /// Rollback the list of changes. This occurs when an error was raised when applying the updates
        /// </summary>
        protected virtual void Rollback()
        {
            
        }

        private void AddUpdateConflict(T currentItem, T requestedUpdateItem)
        {
            conflicts.Add(new ConflictItem<T>(currentItem, requestedUpdateItem));
        }

        private void AddDeleteConflict(T item)
        {
            conflicts.Add(new ConflictItem<T>(item));
        }

        /// <summary>
        /// Perform the syncronization against the system. 
        /// </summary>
        /// <param name="items">The items to apply against the synchronisation</param>
        /// <param name="forceChanges">Should the changes be applied. The default is false which means that conflict resolution will be used. Otherwise all the changes
        /// that are sent will be applied against the system
        /// </param>
        /// <returns></returns>
        public virtual SyncResult<T> Process(IEnumerable<T> items, bool forceChanges = false)
        {
            result = new SyncResult<T>();

            Setup();
            try
            {
                // Go through all the items and add them to the collection and sync them            
                var deletedItems = items.Where(item => item.IsDeleted).ToList();
                var updatedItems = items.Where(item => item.Id > 0 && item.IsDeleted == false).ToList();
                var insertedItems = items.Where(item => item.Id == 0).ToList();

				var correlationIds = new Dictionary<string, int>();

                // Go through each of these items and process them
                foreach (var item in insertedItems)
                {
                    int id = Insert(item);
					correlationIds[item.CorrelationId] = id;
                    Audit(AuditAction.Insert, item);
                }

                foreach (var item in updatedItems)
                {
                    // Check for a conflict
                    var localVersion = GetItem(item);

                    if (localVersion == null && !forceChanges)
                    {
                        // The record has been removed. Add that to the conflict list
                        AddDeleteConflict(item);
                    }
                    else
                    {
                        if (localVersion.VersionNumber != item.VersionNumber && !forceChanges)
                            AddUpdateConflict(localVersion, item);
                        else
                        {
                            item.VersionNumber = localVersion.VersionNumber + 1;
                            Update(item);
                            Audit(AuditAction.Update, item);                        
                        }
                    }
                }

                foreach (var item in deletedItems)
                {
                    // Check for a conflict
                    Delete(item);
                    Audit(AuditAction.Delete, item);
                }

                Commit();

				result.CorrelationIds = correlationIds;
                result.Conflicts = conflicts.ToArray();

                if (conflicts.Count == 0)
                    result.Status = SyncStatus.Success;
                else
                    result.Status = SyncStatus.PartialSuccessWithConflict;
            }
            catch (Exception)
            {
                result.Status = SyncStatus.Failed;

                Rollback();
            }

            return result;            
        }
    }
}
