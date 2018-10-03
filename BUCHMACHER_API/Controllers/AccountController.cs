using BUKMACHER_INFRASTRUCTURE.Commands;
using BUKMACHER_INFRASTRUCTURE.Commands.User;
using BUKMACHER_INFRASTRUCTURE.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BUKMACHER_API.Controllers
{
    public class AccountController : ApiControllerBase
    {
        public AccountController(IUserService userService, ICommandDispatcher commandDispatcher) : base(commandDispatcher)
        {}

        [HttpPut("")]
        public async Task<IActionResult> ChangePassword([FromBody]ChangeUserPassword command)
        {
            await CommandDispatcher.DispatchAsync(command);
            return NoContent();
        }
    }
}
