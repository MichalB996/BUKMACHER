using BUKMACHER_INFRASTRUCTURE.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace BUKMACHER_INFRASTRUCTURE.Services
{
    public interface IUserService
    {
        void Register(string email, string password, string username);
        UserDTO Get(string email);
    }
}
