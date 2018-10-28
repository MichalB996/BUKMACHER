using Microsoft.AspNetCore.Mvc;
using SportsBetting.Infrastructure.Commands;

namespace SportsBetting.Controllers
{
    [Route("[controller]")]
    public abstract class ApiControllerBase : Controller
    {
        protected readonly ICommandDispatcher CommandDispatcher;

        protected ApiControllerBase(ICommandDispatcher commandDispatcher)
        {
            CommandDispatcher = commandDispatcher;
        } 
    }
}
