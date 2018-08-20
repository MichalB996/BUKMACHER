using BUKMACHER_INFRASTRUCTURE.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BUKMACHER_INFRASTRUCTURE.Services
{
    public interface IBukmacherService
    {
        Task RegisterAsync(string name);
        Task<BukmacherDTO> GetAsync(string email);
    }
}
