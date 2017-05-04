using System.Collections.Generic;
using MobileSync.Models;

namespace MobileSync.Models
{
    /// <summary>
    /// Defines the result to send back to the 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class SyncResult<T> where T : SyncObject
    {
        public SyncStatus Status { get; set; }

        public ConflictItem<T>[] Conflicts { get; set; }

		public Dictionary<string, int> CorrelationIds { get; set; }
    }
}