using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using CtlgEver.Core.Domains;
using CtlgEver.Infrastructure.DTO;
using CtlgEver.Infrastructure.Repositories.Interfaces;
using CtlgEver.Infrastructure.Services.Interfaces;

namespace CtlgEver.Infrastructure.Services
{
    public class SheetService : ISheetService
    {
        public readonly IMapper _mapper;
        public readonly ISheetRepository _sheetRepository;

        public SheetService(IMapper mapper, ISheetRepository sheetRepository)
        {
            _mapper = mapper;
            _sheetRepository = sheetRepository;
        }

        public async Task<IEnumerable<SheetDto>> BrowseAsync(int userId)
        {
            var sheets = await _sheetRepository.BrowseByUserAsync(userId);
            return _mapper.Map<IEnumerable<SheetDto>> (sheets);
        }

        public async Task CreateAsync(string name, int userId)
        {
            var sheet = new Sheet(name , userId);
            await _sheetRepository.AddAsync(sheet);
        }

        public async Task DeleteAsync(int id)
        {
            var sheet = await _sheetRepository.GetAsync(id);
            await _sheetRepository.DeleteAsync(sheet);
        }

        public async Task<SheetDto> GetAsync(int SheetId)
        {
            var sheet = await _sheetRepository.GetAsync(SheetId);
            return _mapper.Map<SheetDto> (sheet);
        }

        public async Task UpdateAsync(int id, string name)
        {
            var sheet = await _sheetRepository.GetAsync(id);
            sheet.Update(name);
            await _sheetRepository.UpdateAsync(sheet);
        }
    }
}