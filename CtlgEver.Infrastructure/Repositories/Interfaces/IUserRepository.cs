using System.Collections.Generic;
using System.Threading.Tasks;
using CtlgEver.Core.Domains;

namespace CtlgEver.Infrastructure.Repositories
{
    public interface IUserRepository
    {
        Task<User> GetByIdAsync(bool IsNoTracking);
        Task<User> GetByEmailAsync(bool IsNoTracking);
        Task<IEnumerable<User>> BrowseAsync();
        Task AddAsync(User user);
        Task UpdateAsync(User user);
        Task DeleteAsync(User user);
    }
}