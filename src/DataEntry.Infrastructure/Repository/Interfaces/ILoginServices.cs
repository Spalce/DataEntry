using DataEntry.Infrastructure.Models.Identity;
using System.Threading.Tasks;

namespace DataEntry.Infrastructure.Repository.Interfaces
{
    public interface ILoginServices
    {
        void Login(string token);
        Task LogOut();
        Task<UserDetail> GetUserDetails();
    }
}
