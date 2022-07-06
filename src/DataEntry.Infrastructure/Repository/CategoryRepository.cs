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
    public class CategoryRepository : ICategoryRepository
    {
        private readonly AppDbContext db;

        public CategoryRepository(AppDbContext db)
        {
            this.db = db;
        }

        public async Task<Category> CreateAsync(Category Category)
        {
            await db.Categories.AddAsync(Category);
            await Save();
            return Category;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var item = await db.Categories.FindAsync(id);
            if (item == null)
            {
                return false;
            }

            db.Categories.Remove(item);
            await Save();
            return true;
        }

        public async Task<IEnumerable<Category>> GetAllAsync()
        {
            var items = await db.Categories.ToListAsync();
            return items;
        }

        public async Task<Category> GetByIdAsync(int id)
        {
            var item = await db.Categories.FindAsync(id);
            if (item == null)
            {
                return null;
            }

            return item;
        }

        public async Task Save()
        {
            await db.SaveChangesAsync();
        }

        public async Task<Category> UpdateAsync(Category Category)
        {
            var item = await db.Categories.FindAsync(Category.Id);
            if (item == null)
            {
                return null;
            }

            item.Description = Category.Description;
            item.Name = Category.Name;

            db.Categories.Update(item);
            await Save();
            return Category;
        }
    }
}
