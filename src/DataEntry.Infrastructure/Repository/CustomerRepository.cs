using DataEntry.Infrastructure.Data;
using DataEntry.Infrastructure.Models;
using DataEntry.Infrastructure.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataEntry.Infrastructure.Repository
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly AppDbContext db;

        public CustomerRepository(AppDbContext db)
        {
            this.db = db;
        }

        public async Task<Customer> CreateAsync(Customer Customer)
        {
            await db.Customers.AddAsync(Customer);
            await Save();
            return Customer;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var item = await db.Customers.FindAsync(id);
            if (item == null)
            {
                return false;
            }

            db.Customers.Remove(item);
            await Save();
            return true;
        }

        public async Task<IEnumerable<Customer>> GetAllAsync()
        {
            var items = await db.Customers.ToListAsync();
            return items;
        }

        public async Task<Customer> GetByIdAsync(int id)
        {
            var item = await db.Customers.FindAsync(id);
            if (item == null)
            {
                return null;
            }

            return item;
        }

        public async Task Save()
        {
            await db.SaveChangesAsync().ConfigureAwait(false);
        }

        public async Task<Customer> UpdateAsync(Customer Customer)
        {
            var item = await db.Customers.FindAsync(Customer.Id);
            if (item == null)
            {
                return null;
            }

            item.Phone = Customer.Phone;
            item.Email = Customer.Email;
            item.Name = Customer.Name;

            db.Customers.Update(item);
            await Save();
            return Customer;
        }
    }
}
