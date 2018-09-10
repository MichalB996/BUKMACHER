using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BUKMACHER_CORE.Domain;
using BUKMACHER_INFRASTRUCTURE.Commands;
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
        private readonly ICommandDispatcher _commandDispatcher;
        public UserController(IUserService userService, ICommandDispatcher commandDispatcher)
        {
            _commandDispatcher = commandDispatcher;
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
        public async Task<IActionResult> Post([FromBody]CreateUser command)
        {
            await _commandDispatcher.DispatchAsync(command);

            return Created($"user/{command.Email}", new object());
        }
    }
}


