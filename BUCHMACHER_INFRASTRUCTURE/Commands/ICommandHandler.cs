using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BUKMACHER_INFRASTRUCTURE.Commands
{
    // Interface ussed for handling concrete command.
    interface ICommandHandler<T> where T : ICommand
    {
        Task HandleAsync(T command);
    }
}
