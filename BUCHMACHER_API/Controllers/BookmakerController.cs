using Microsoft.AspNetCore.Mvc;
using SportsBetting.Infrastructure.DTO;
using SportsBetting.Infrastructure.Services;
using System.Threading.Tasks;

namespace SportsBetting.Controllers
{
    [Route("[controller]")]
    public class BookmakerController : Controller
    {
        private readonly IBookmakerService _bookmakerService;
        public BookmakerController(IBookmakerService bookmakerService)
        {
            _bookmakerService = bookmakerService;
        }
        [HttpGet("{name}")]
        public async Task<BookmakerDTO> Get(string name)
            => await _bookmakerService.GetAsync(name);
    }
}

