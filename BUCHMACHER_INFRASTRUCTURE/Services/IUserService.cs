using BUKMACHER_INFRASTRUCTURE.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BUKMACHER_INFRASTRUCTURE.Services
{
    public interface IUserService
    {
        Task RegisterAsync(string email, string password, string username);
        Task<UserDTO> GetAsync(string email);
    }
}
