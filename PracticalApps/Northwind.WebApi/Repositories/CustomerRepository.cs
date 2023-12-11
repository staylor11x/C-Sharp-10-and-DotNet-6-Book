using Microsoft.EntityFrameworkCore.ChangeTracking; //EntityEntry<T>
using Packt.Shared;     //Customer
using System.Collections.Concurrent;
using System.Security.Cryptography.X509Certificates;    //ConcurrentDictionary


namespace Northwind.WebApi.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        // use a static thread-safe dictionary to cache the customers
        private static ConcurrentDictionary<string, Customer?> customersCache;

        // use an instance data context field because it should not be cached due to their internal cahcing
        private NorthwindContext db;

        public CustomerRepository(NorthwindContext injectedContext) 
        {
            db = injectedContext;

            //pre-load the customers from the database as normal
            //Dictionary with CustomerId as the key, then convert to a thread safe ConcurrentDictionary

            if(customersCache == null)
            {
                customersCache = new ConcurrentDictionary<string, Customer?>(db.Customers.ToDictionary(c => c.CustomerId));
            }
        }

        public async Task<Customer?> CreateAsync(Customer c)
        {
            //normalise the customerId to uppercase
            c.CustomerId = c.CustomerId.ToUpper();

            //add to database using EF Core
            EntityEntry<Customer> added = await db.Customers.AddAsync(c);
            int affected = await db.SaveChangesAsync();

            if (affected == 1)
            {
                if (customersCache is null) return c;
                //if the customer cache is new then add it to the cahce, otherwise call the UpdateCache method
                return customersCache.AddOrUpdate(c.CustomerId, c, UpdateCache);
            }
            else
            {
                return null;
            }
        }

        public Task<IEnumerable<Customer>> RetrieveAllAsync()
        {
            //for performance, get from cache
            return Task.FromResult(customersCache is null ? Enumerable.Empty<Customer>() : customersCache.Values);
        }

        public Task<Customer?> RetrieveAsync(string id)
        {
            //for performance, get from cache
            id = id.ToUpper();
            if (customersCache is null) return null;

            customersCache.TryGetValue(id, out Customer? c);
            return Task.FromResult(c);
        }

        private Customer UpdateCache(string id, Customer c)
        {
            Customer? old;
            if(customersCache is not null)
            {
                if(customersCache.TryGetValue(id, out old))
                {
                    if(customersCache.TryUpdate(id,c,old))
                    {
                        return c;
                    }
                }
            }
            return null;
        }

        public async Task<Customer?> UpdateAsync(string id, Customer c)
        {
            //normalise customer id
            id = id.ToUpper();
            c.CustomerId = c.CustomerId.ToUpper();

            //update the database
            db.Customers.Update(c);
            int affected = await db.SaveChangesAsync(c);
            if (affected == 1)
            {
                //update in cache
                return UpdateCache(id, c);
            }
            return null;
        }

        public async Task<bool?> DeleteAsync(string id)
        {
            id = id.ToUpper();

            //remove from database
            Customer? c = db.Customers.Find(id);
            if(c is null) return null;
            db.Customers.Remove(c);
            int affected = await db.SaveChangesAsync();

            if(affected == 1)
            {
                if (customersCache is null) return null;
                //remove from cache
                return customersCache.TryRemove(id, out c);
            }
            else
            {
                return null;
            }
        }
    }
}
