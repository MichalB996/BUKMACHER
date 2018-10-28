using System.Threading.Tasks;

namespace SportsBetting.Infrastructure.Commands
{
    interface ICommandHandler<T> where T : ICommand
    {
        Task HandleAsync(T command);
    }
}
