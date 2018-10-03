using BUKMACHER_INFRASTRUCTURE.Commands;
using BUKMACHER_INFRASTRUCTURE.Commands.User;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BUKMACHER_INFRASTRUCTURE.Handlers.Users
{
    class ChangeUserPasswordHandler : ICommandHandler<ChangeUserPassword>
    {
        public async Task HandleAsync(ChangeUserPassword command)
        {
            await Task.CompletedTask;
        }
    }
}
