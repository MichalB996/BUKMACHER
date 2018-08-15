using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BUKMACHER_INFRASTRUCTURE.Commands.User;
using BUKMACHER_INFRASTRUCTURE.DTO;
using BUKMACHER_INFRASTRUCTURE.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BUKMACHER_API.Controllers
{
    //[Produces("application/json")]
    [Route("[controller]")]
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        [HttpGet("{email}")]
        public UserDTO Get(string email)
            => _userService.Get(email);
        [HttpPost("")]
        public void Post([FromBody]CreateUser request)
        {
            _userService.Register(request.Email,request.Password,request.Username);
        }
    }
}

