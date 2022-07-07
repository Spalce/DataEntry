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
    public class SaleItemRepository : ISaleItemRepository
    {
        private readonly AppDbContext db;

        public SaleItemRepository(AppDbContext db)
        {
            this.db = db;
        }

        public async Task<List<SaleItem>> CreateAsync(List<SaleItem> SaleItem)
        {
            await db.SaleItems.AddRangeAsync(SaleItem);
            await Save();
            return SaleItem;
        }

        public async Task<IEnumerable<SaleItem>> GetAllAsync()
        {
            var items = await db.SaleItems.ToListAsync();
            return items;
        }
        
        public async Task<SaleItem> GetByIdAsync(int id)
        {
            var item = await db.SaleItems.FindAsync(id);
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
    }
}
