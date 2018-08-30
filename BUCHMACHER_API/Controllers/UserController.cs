using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BUKMACHER_CORE.Domain;
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
        public async Task<IActionResult> Get(string email)
        {
            var user = await _userService.GetAsync(email);
            if (user == null)
                return NotFound("User not found!");
            return Json(user);
        }
        [HttpPost("")]
        public async Task<IActionResult> Post([FromBody]CreateUser request)
        {
            await _userService.RegisterAsync(request.Email,request.Password,request.Username);


            return Created($"user/{request.Email}", new object());
        }
    }
}


