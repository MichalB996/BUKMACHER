using AutoMapper;
using SportsBetting.Core.Domain;
using SportsBetting.Core.Repositories;
using SportsBetting.Infrastructure.DTO;
using System;
using System.Threading.Tasks;

namespace SportsBetting.Infrastructure.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        public UserService(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;

        }

        public async Task<UserDTO> GetAsync(string email)
        {
            var user = await _userRepository.GetAsync(email);
            return await Task.FromResult(_mapper.Map<User, UserDTO>(user));
        }

        public async Task RegisterAsync(string email, string password, string username)
        {
            var user = await _userRepository.GetAsync(email);
            if(user != null)
            {
                throw new Exception($"User with email: {email} already exists.");
            }
            var salt = Guid.NewGuid().ToString("N");
            user = new User(email, password, username,salt);
            await _userRepository.AddAsync(user);
            await Task.CompletedTask;
        }
    }
}
