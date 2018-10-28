using SportsBetting.Core.Domain;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SportsBetting.Core.Repositories
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
