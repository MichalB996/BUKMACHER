using AutoMapper;
using BUKMACHER_CORE.Domain;
using BUKMACHER_CORE.Repositories;
using BUKMACHER_INFRASTRUCTURE.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BUKMACHER_INFRASTRUCTURE.Services
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
