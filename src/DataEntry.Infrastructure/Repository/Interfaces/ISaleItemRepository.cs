using DataEntry.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataEntry.Infrastructure.Repository.Interfaces
{
    public interface ISaleItemRepository
    {
        Task<IEnumerable<SaleItem>> GetAllAsync();
        Task<SaleItem> GetByIdAsync(int id);
        Task<List<SaleItem>> CreateAsync(List<SaleItem> SaleItem);
        Task Save();
    }
}
