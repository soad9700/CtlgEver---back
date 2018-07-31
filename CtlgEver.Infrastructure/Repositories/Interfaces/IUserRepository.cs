using System.Collections.Generic;
using System.Threading.Tasks;
using CtlgEver.Core.Domains;

namespace CtlgEver.Infrastructure.Repositories
{
    public interface IUserRepository
    {
        Task<User> GetByIdAsync(int id, bool IfNoTracking = false);
        Task<User> GetByEmailAsync(string email, bool IfNoTracking = false);
        Task AddAsync(User user);
        Task UpdateAsync(User user);
        Task DeleteAsync(User user);
    }
}