using System.Threading.Tasks;
using CtlgEver.Core.Domains;
using CtlgEver.Infrastructure.DTO;

namespace CtlgEver.Infrastructure.Services.Interfaces
{
    public interface IUserService
    {
        Task RegisterAsync(User user);
        Task DeleteAsync(User user);
        Task GetByIdAsync(UserDto user);
        Task GetByEmailAsync(UserDto user);
        Task UpdateAsync(User user);
    }
}