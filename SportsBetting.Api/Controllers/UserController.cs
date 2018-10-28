using Microsoft.AspNetCore.Mvc;
using SportsBetting.Infrastructure.Commands;
using SportsBetting.Infrastructure.Commands.User;
using SportsBetting.Infrastructure.Services;
using System.Threading.Tasks;

namespace SportsBetting.Controllers
{

    public class UserController : ApiControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService, ICommandDispatcher commandDispatcher) : base(commandDispatcher)
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
        public async Task<IActionResult> Post([FromBody]CreateUser command)
        {
            await CommandDispatcher.DispatchAsync(command);
            return Created($"user/{command.Email}", new object());
        }

    }
}


