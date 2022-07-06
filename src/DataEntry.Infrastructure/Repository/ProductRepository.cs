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
    public class ProductRepository : IProductRepository
    {
        private readonly AppDbContext db;

        public ProductRepository(AppDbContext db)
        {
            this.db = db;
        }
        
        public async Task<Product> CreateAsync(Product product)
        {
            await db.Products.AddAsync(product);
            await Save();
            return product;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var item = await db.Products.FindAsync(id);
            if (item == null)
            {
                return false;
            }

            db.Products.Remove(item);
            await Save();
            return true;
        }

        public async Task<IEnumerable<Product>> GetAllAsync()
        {
            var items = await db.Products.ToListAsync();
            return items;
        }

        public async Task<Product> GetByIdAsync(int id)
        {
            var item = await db.Products.FindAsync(id);
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

        public async Task<Product> UpdateAsync(Product product)
        {
            var item = await db.Products.FindAsync(product.Id);
            if (item == null)
            {
                return null;
            }

            item.Price = product.Price;
            item.CategoryId = product.CategoryId;
            item.Description = product.Description;
            item.Name = product.Name;

            db.Products.Update(item);
            await Save();
            return product;
        }       
    }
}
