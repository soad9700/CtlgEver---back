using AutoMapper;
using CtlgEver.Core.Domains;
using CtlgEver.Infrastructure.DTO;

namespace CtlgEver.Infrastructure.Mappers
{
    public static class AutoMapperConfig
    {
        public static IMapper Initialize () =>
        new MapperConfiguration (cfg =>
        {
            cfg.CreateMap<User,UserDto>();
            cfg.CreateMap<Sheet,SheetDto>();
        })
        .CreateMapper();
    }
}