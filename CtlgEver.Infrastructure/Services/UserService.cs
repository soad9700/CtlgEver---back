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
        private readonly IUserRepository _userRepository;

        public UserService (IMapper mapper, IUserRepository userRepository)
        {
            _mapper = mapper;
            _userRepository = userRepository;
        }

        public async Task<User> LoginAsync(string email, string password)
        {
            var user = await _userRepository.GetByEmailAsync(email, true);
            if (user == null || user.Deleted)
                return null;
            if(!VerifyPasswordHash(password, user.PasswordHash, user.PasswordSalt))
                return null;
            return user;
        }
        private bool VerifyPasswordHash (string password, byte[] passwordHash, byte[] passwordSalt) {
            using (var hmac = new System.Security.Cryptography.HMACSHA512 (passwordSalt)) {
                var computedHash = hmac.ComputeHash (System.Text.Encoding.UTF8.GetBytes (password));
                for (int i = 0; i < computedHash.Length; i++) {
                    if (computedHash[i] != passwordHash[i]) return false;
                }
                return true;
            }
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

        public async Task UpdateAsync(int id, string name, string surname)
        {
            var user = await _userRepository.GetByIdAsync(id);
            user.Update(name, surname);
            await _userRepository.UpdateAsync(user);
        }
    }
}