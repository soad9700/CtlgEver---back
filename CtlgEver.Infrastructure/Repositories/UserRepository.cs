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


    }
}