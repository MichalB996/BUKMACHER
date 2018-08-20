using BUKMACHER_CORE.Domain;
using BUKMACHER_CORE.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUKMACHER_INFRASTRUCTURE.Repositories
{
    class InMemoryPlayerRepository : IPlayerRepository
    {
        private static ISet<Player> _players = new HashSet<Player>();

        public async Task AddAsync(Player player)
        {
            _players.Add(player);
            await Task.CompletedTask;
        }

        public async Task<Player> GetAsync(string email)
            => await Task.FromResult(_players.Single(x => x.Email == email.ToLowerInvariant()));

        public async Task<Player> GetAsync(Guid Id)
            => await Task.FromResult(_players.Single(x => x.Id == Id));

        public async Task<IEnumerable<Player>> GetAllAsync()
            => await Task.FromResult(_players);

        public async Task RemoveAsync(Guid id)
        {
            var player =await GetAsync(id);
            _players.Remove(player);
            await Task.CompletedTask;
        }

        public async Task UpdateAsync(Guid id)
        {
            await Task.CompletedTask;
        }
    }
}
