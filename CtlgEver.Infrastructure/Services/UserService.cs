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

        public async Task DeleteAsync(int id)
        {
            var user = await _userRepository.GetByIdAsync(id);
            await _userRepository.DeleteAsync(user);
        }

        public async Task<UserDto> GetByEmailAsync(string email)
        {
            var user= await _userRepository.GetByEmailAsync(email);
            return _mapper.Map<UserDto> (user);
        }

        public async Task<UserDto> GetByIdAsync(int id)
        {
            var user= await _userRepository.GetByIdAsync(id);
            return _mapper.Map<UserDto> (user);
        }

        public async Task RegisterAsync(string name, string surname, string email, string password)
        {
            var user = new User(name, surname, email, password);
            await _userRepository.AddAsync(user);
        }

        //nie działa nie wiem czemu
        /* public async Task UpdateAsync(int id, string name, string surname)
        {
            var user = _userRepository.GetByIdAsync(id);
            user.Update(name, surname);
            await _userRepository.UpdateAsync(user);
        } */
    }
}