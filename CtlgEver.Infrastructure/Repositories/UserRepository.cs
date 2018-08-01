using System.Collections.Generic;
using System.Threading.Tasks;
using CtlgEver.Core.Domains;
using CtlgEver.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace CtlgEver.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly CtlgEverContext _context;
        public UserRepository(CtlgEverContext context)
        {
            _context = context;
        }

        public async Task AddAsync(User user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(User user)
        {
            _context.Users.Remove(user);
            await Task.CompletedTask;
        }

        public async Task<User> GetByEmailAsync(string email, bool IfNoTracking = false)
        {
            if(IfNoTracking)
                return await _context.Users.AsNoTracking().SingleOrDefaultAsync(u => u.Email == email);
            return await _context.Users.SingleOrDefaultAsync (u => u.Email == email);
        }

        public async Task<User> GetByIdAsync(int id, bool IfNoTracking = false)
        {
            if(IfNoTracking)
                return await _context.Users.AsNoTracking().SingleOrDefaultAsync(u => u.UserId == id);
            return await _context.Users.SingleOrDefaultAsync (u => u.UserId == id);
        }

        public async Task UpdateAsync(User user)
        {
            _context.Users.Update(user);
            await _context.SaveChangesAsync();
        }
    }
}