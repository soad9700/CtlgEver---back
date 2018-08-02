using System.Collections.Generic;
using System.Threading.Tasks;
using CtlgEver.Core.Domains;

namespace CtlgEver.Infrastructure.Repositories.Interfaces
{
    public interface ISheetRepository
    {
        Task GetAsync(int id);
        Task<IEnumerable<Sheet>> BrowseByUserAsync(int userId);
        Task CreateAsync(Sheet sheet);
        Task UpdateAsync(Sheet sheet);
        Task DeleteAsync(Sheet sheet);
    }
}