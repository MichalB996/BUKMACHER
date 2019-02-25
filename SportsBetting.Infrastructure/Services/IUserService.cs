using SportsBetting.Infrastructure.DTO;
using System.Threading.Tasks;

namespace SportsBetting.Infrastructure.Services
{
    public interface IUserService : IService
    {
        Task RegisterAsync(string email, string password, string username);
        Task<UserDTO> GetAsync(string email);
    }
}
