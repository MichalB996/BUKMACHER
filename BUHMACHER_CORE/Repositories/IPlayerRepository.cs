using BUKMACHER_CORE.Domain;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BUKMACHER_CORE.Repositories
{
    public interface IPlayerRepository
    {
        Task<Player> GetAsync(string email);
        Task<Player> GetAsync(Guid Id);
        Task AddAsync(Player user);
        Task RemoveAsync(Guid id);
        Task UpdateAsync(Guid id);
        Task<IEnumerable<Player>> GetAllAsync();
    }
}
