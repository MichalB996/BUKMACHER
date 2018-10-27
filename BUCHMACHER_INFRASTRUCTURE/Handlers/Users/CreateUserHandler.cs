using SportsBetting.Infrastructure.Commands;
using SportsBetting.Infrastructure.Commands.User;
using SportsBetting.Infrastructure.Services;
using System.Threading.Tasks;

namespace SportsBetting.Infrastructure.Handlers.Users
{
    class CreateUserHandler : ICommandHandler<CreateUser>
    {
        private readonly IUserService _userService;

        public CreateUserHandler(IUserService userService)
        {
            _userService = userService;
        }

        public async Task HandleAsync(CreateUser command)
        {
            await _userService.RegisterAsync(command.Email, command.Password, command.Username);
        }
    }
}
