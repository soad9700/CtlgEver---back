using System.Threading.Tasks;
using AutoMapper;
using CtlgEver.Core.Domains;
using CtlgEver.Infrastructure.DTO;
using CtlgEver.Infrastructure.Repositories;
using CtlgEver.Infrastructure.Services.Interfaces;

namespace CtlgEver.Infrastructure.Services
{
    public class UserService : IUserService
    {
        private readonly IMapper _mapper;
        private readonly UserRepository _userRepository;

        public UserService (IMapper mapper, UserRepository userRepository)
        {
            mapper = _mapper;
            userRepository = _userRepository;
        }

        public Task DeleteAsync(User user)
        {
            throw new System.NotImplementedException();
        }

        public Task GetByEmailAsync(UserDto user)
        {
            throw new System.NotImplementedException();
        }

        public Task GetByIdAsync(UserDto user)
        {
            throw new System.NotImplementedException();
        }

        public Task RegisterAsync(User user)
        {
            throw new System.NotImplementedException();
        }

        public Task UpdateAsync(User user)
        {
            throw new System.NotImplementedException();
        }
    }
}