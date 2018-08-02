using System.Threading.Tasks;
using CtlgEver.Core.Domains;
using CtlgEver.Infrastructure.DTO;

namespace CtlgEver.Infrastructure.Services.Interfaces
{
    public interface IUserService
    {
        Task RegisterAsync(string name, string surname, string email, string password);
        Task DeleteAsync(int id);
        Task<UserDto> GetByIdAsync(int id);
        Task<UserDto> GetByEmailAsync(string email);
        Task UpdateAsync(int id, string name, string surname);
    }
}