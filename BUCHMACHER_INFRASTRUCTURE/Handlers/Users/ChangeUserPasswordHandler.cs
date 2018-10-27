using SportsBetting.Infrastructure.Commands;
using SportsBetting.Infrastructure.Commands.User;
using System.Threading.Tasks;

namespace SportsBetting.Infrastructure.Handlers.Users
{
    class ChangeUserPasswordHandler : ICommandHandler<ChangeUserPassword>
    {
        public async Task HandleAsync(ChangeUserPassword command)
        {
            await Task.CompletedTask;
        }
    }
}
