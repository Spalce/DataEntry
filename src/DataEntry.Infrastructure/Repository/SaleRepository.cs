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
    public class SaleRepository : ISaleRepository
    {
        private readonly AppDbContext db;

        public SaleRepository(AppDbContext db)
        {
            this.db = db;
        }

        public async Task<Sale> CreateAsync(Sale Sale)
        {
            Sale.Date = DateTime.Now;
            await db.Sales.AddAsync(Sale);
            await Save();
            return Sale;
        }

        public async Task<IEnumerable<Sale>> GetAllAsync()
        {
            var items = await db.Sales.ToListAsync();
            return items;
        }

        public async Task<Sale> GetByIdAsync(int id)
        {
            var item = await db.Sales.FindAsync(id);
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
