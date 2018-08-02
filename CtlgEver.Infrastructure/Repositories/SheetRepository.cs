using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CtlgEver.Core.Domains;
using CtlgEver.Infrastructure.Data;
using CtlgEver.Infrastructure.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CtlgEver.Infrastructure.Repositories
{
    public class SheetRepository : ISheetRepository
    {
        private readonly CtlgEverContext _context;
        public SheetRepository(CtlgEverContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Sheet>> BrowseByUserAsync(int userId)
        {
            var sheets = _context.Sheets.Where(u => u.UserId == userId).AsEnumerable();
            return await Task.FromResult(sheets);
        }

        public async Task CreateAsync(Sheet sheet)
        {
            _context.Sheets.Add(sheet);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Sheet sheet)
        {
            _context.Sheets.Remove(sheet);
            await _context.SaveChangesAsync();
        }

        public async Task GetAsync(int id)
        {
            var sheet = _context.Sheets.SingleOrDefaultAsync(i => i.SheetId == id);
            await Task.FromResult(sheet);
        }

        public async Task UpdateAsync(Sheet sheet)
        {
            _context.Sheets.Update(sheet);
            await _context.SaveChangesAsync();
        }
    }
}