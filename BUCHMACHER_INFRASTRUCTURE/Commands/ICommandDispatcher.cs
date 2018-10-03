using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BUKMACHER_INFRASTRUCTURE.Commands
{
    // Interface to dispach concrete command in UsersController.
    public interface ICommandDispatcher
    {
        Task DispatchAsync<T>(T command) where T : ICommand;
    }
}
