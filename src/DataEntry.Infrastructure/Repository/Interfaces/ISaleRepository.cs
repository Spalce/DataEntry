using DataEntry.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataEntry.Infrastructure.Repository.Interfaces
{
    public interface ISaleRepository
    {
        Task<IEnumerable<Sale>> GetAllAsync();
        Task<IEnumerable<SaleItem>> GetAllItemsAsync(int id);
        Task<Sale> GetByIdAsync(int id);
        Task<Sale> CreateAsync(Sale Sale);
        Task Save();
    }
}
