using System.Collections.Generic;
using System.Threading.Tasks;
using CtlgEver.Core.Domains;
using CtlgEver.Infrastructure.Data;

namespace CtlgEver.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        CtlgEverContext _context;
        public UserRepository(CtlgEverContext context)
        {
            _context = context;
        }

        public Task AddAsync(User user)
        {
            throw new System.NotImplementedException();
        }

        public Task<IEnumerable<User>> BrowseAsync()
        {
            throw new System.NotImplementedException();
        }

        public Task DeleteAsync(User user)
        {
            throw new System.NotImplementedException();
        }

        public Task<User> GetByEmailAsync(bool IsNoTracking)
        {
            throw new System.NotImplementedException();
        }

        public Task<User> GetByIdAsync(bool IsNoTracking)
        {
            throw new System.NotImplementedException();
        }

        public Task UpdateAsync(User user)
        {
            throw new System.NotImplementedException();
        }
    }
}