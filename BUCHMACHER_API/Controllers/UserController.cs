using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BUCHMACHER_API.Models;
using BUKMACHER_INFRASTRUCTURE;
using BUKMACHER_CORE;
using BUKMACHER_INFRASTRUCTURE.Services;
using BUKMACHER_INFRASTRUCTURE.DTO;

namespace BUCHMACHER_API.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        public UserDTO Get(string email)
            => _userService.Get(email);


        
    }
}
