using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using CustomerSync.Models;
using log4net.Repository.Hierarchy;
using MobileSync.Server;
using MobileSync.Models;
using ServiceStack.Text;

namespace ServerSyncApi.Controllers
{
	// An example instance of how the sync could potentially occur. 
	public class CustomerDataSync : BaseServerSync<Customer>
	{
		readonly log4net.ILog logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
		private static readonly Dictionary<long, Customer> _allCustomers = new Dictionary<long, Customer>();
		private static int _currentCustomerId = 0;
		private static object _lock = new object();

		public IEnumerable<Customer> GetCustomers()
		{
			var customers = _allCustomers.Values.Where(c => c.IsDeleted == false).ToList();
			logger.Debug(String.Format("GetCustomers: {0}",customers.Dump()));
			return customers;
		}

		public Customer GetItem(long id)
		{
			logger.Debug(String.Format("GetItem {0}", id));
			if (_allCustomers.ContainsKey(id))
				return _allCustomers[id];

			return null;
		}

		public override Customer GetItem(Customer item)
		{
			logger.Debug(String.Format("GetItem {0}", item.Dump()));
			if (_allCustomers.ContainsKey(item.Id))
				return _allCustomers[item.Id];

			return null;
		}

		public override int Insert(Customer item)
		{
			logger.Debug(String.Format("Insert {0}", item.Dump()));
			_currentCustomerId++;
			item.Id = _currentCustomerId;
			_allCustomers[item.Id] = item;
			return 0;
		}

		public override void Update(Customer item)
		{
			logger.Debug(String.Format("Update {0}", item.Id));
			_allCustomers[item.Id] = item;
		}

		public override void Delete(Customer item)
		{
			logger.Debug(String.Format("Delete {0}", item.Id));
			_allCustomers.Remove(item.Id);
		}
	}

	public class CustomersController : ApiController
	{
		readonly log4net.ILog logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
		public CustomerDataSync _sync = new CustomerDataSync();

		public IEnumerable<Customer> Get()
		{
			logger.Debug("Get Customers");
			return _sync.GetCustomers();
		}

		public Customer Get(long id)
		{
			logger.Debug(String.Format("Get Customer {0}", id));
			return _sync.GetItem(id);
		}

		/// <summary>
		/// Sync the items to the list
		/// </summary>
		/// <param name="customers"></param>
		public SyncResult<Customer> Post([FromBody] Customer[] customers)
		{
			logger.Debug(String.Format("Post {0}", customers.Dump()));
			//http://localhost/ServerSyncApi/Properties/
			return _sync.Process(customers);
		}

		// Update the elements from the list and ensure that they forced to be updated
		public SyncResult<Customer> Put([FromBody] Customer[] customers)
		{
			logger.Debug(String.Format("Put {0}", customers.Dump()));
			return _sync.Process(customers, true);
		}
	}
}
