using System.Collections.Generic;
using System.Threading.Tasks;
using CtlgEver.Core.Domains;

namespace CtlgEver.Infrastructure.Repositories.Interfaces
{
    public interface ISheetRepository
    {
        Task<Sheet> GetAsync(int id);
        Task<IEnumerable<Sheet>> BrowseByUserAsync(int userId);
        Task AddAsync(Sheet sheet);
        Task UpdateAsync(Sheet sheet);
        Task DeleteAsync(Sheet sheet);
    }
}