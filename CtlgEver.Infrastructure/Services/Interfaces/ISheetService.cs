using System.Collections.Generic;
using System.Threading.Tasks;
using CtlgEver.Core.Domains;
using CtlgEver.Infrastructure.DTO;

namespace CtlgEver.Infrastructure.Services.Interfaces
{
    public interface ISheetService
    {
        Task<IEnumerable<SheetDto>> BrowseAsync(int userId);
        Task<SheetDto> GetAsync(int SheetId);
        Task CreateAsync(string name, int userId);
        Task DeleteAsync(int id);
        Task UpdateAsync(int id, string name);
    }
}