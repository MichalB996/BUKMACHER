using SportsBetting.Infrastructure.DTO;
using System.Threading.Tasks;

namespace SportsBetting.Infrastructure.Services
{
    public interface IBookmakerService : IService
    {
        Task RegisterAsync(string name);
        Task<BookmakerDTO> GetAsync(string email);
    }
}
