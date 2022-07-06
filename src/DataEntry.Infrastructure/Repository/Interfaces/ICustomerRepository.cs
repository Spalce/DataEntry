using DataEntry.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataEntry.Infrastructure.Repository.Interfaces
{
    public interface ICustomerRepository
    {
        Task<IEnumerable<Customer>> GetAllAsync();
        Task<Customer> GetByIdAsync(int id);
        Task<Customer> CreateAsync(Customer Customer);
        Task<Customer> UpdateAsync(Customer Customer);
        Task<bool> DeleteAsync(int id);
        Task Save();
    }
}
