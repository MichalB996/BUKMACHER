using Microsoft.AspNetCore.Mvc;
using SportsBetting.Infrastructure.Commands;
using SportsBetting.Infrastructure.Commands.User;
using SportsBetting.Infrastructure.Services;
using System.Threading.Tasks;

namespace SportsBetting.Controllers
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
