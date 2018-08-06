using BUKMACHER_CORE.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BUKMACHER_INFRASTRUCTURE.Repositories
{
    class InMemoryPlayerRepository
    {
        private static ISet<Player> _players = new HashSet<Player>();

        public void Add(Player player)
        {
            _players.Add(player);
        }

        public Player Get(string email)
            => _players.Single(x => x.Email == email.ToLowerInvariant());

        public Player Get(Guid Id)
            => _players.Single(x => x.Id == Id);

        public IEnumerable<Player> GetAll()
            => _players;

        public void Remove(Guid id)
        {
            var player = Get(id);
            _players.Remove(player);

        }

        public void Update(Guid id)
        { }
    }
}
