using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
    }
}
/*

    public class AccountController : ApiControllerBase
    {
        private readonly IJwtHandler _jwtHandler;
        
        public AccountController(ICommandDispatcher commandDispatcher, IJwtHandler jwtHandler) 
            : base(commandDispatcher)
        {
            _jwtHandler= jwtHandler;
        }

        [HttpPut]
        [Route("password")]
        public async Task<IActionResult> Put([FromBody]ChangeUserPassword command)
        {
            await DispatchAsync(command);

            return NoContent();
        }        
    }
}
*/
