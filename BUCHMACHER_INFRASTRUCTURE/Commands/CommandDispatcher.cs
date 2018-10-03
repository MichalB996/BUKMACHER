using Autofac;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BUKMACHER_INFRASTRUCTURE.Commands
{
    class CommandDispatcher : ICommandDispatcher
    {
        // Contex for application container.
        private readonly IComponentContext _context;

        public CommandDispatcher(IComponentContext context)
        {
            _context = context;
        }

        public async Task DispatchAsync<T>(T command) where T : ICommand
        {
            if(command == null)
            {
                throw new ArgumentNullException(nameof(command),"Command cannot be null!");
            }
            // Here adequate handler being invoked.
            var handler = _context.Resolve<ICommandHandler<T>>();
            await handler.HandleAsync(command);
        }
    }
}
