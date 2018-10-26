using BUKMACHER_CORE.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BUKMACHER_CORE.Repositories
{
    public interface IBukmacherRepository
    {
        Task<Bukmacher> GetAsync(string email);
        Task<Bukmacher> GetAsync(Guid Id);
        Task AddAsync(Bukmacher user);
        Task RemoveAsync(Guid id);
        Task UpdateAsync(Guid id);
        Task<IEnumerable<Bukmacher>> GetAllAsync();
    }
}
