using SportsBetting.Core.Domain;
using SportsBetting.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportsBetting.Infrastructure.Repositories
{
    public class InMemoryBookmakerRepository : IBookmakerRepository
    {
        private static ISet<Bookmaker> _bookmakers = new HashSet<Bookmaker>()
        {
            Bookmaker.Create("Bookmaker")
        };

        public async Task AddAsync(Bookmaker bookmaker)
        {
            _bookmakers.Add(bookmaker);
        }

        public async Task<Bookmaker> GetAsync(string bookmakerName)
            => await Task.FromResult(_bookmakers.Single(x => x.BookmakerName == bookmakerName));

        public async Task<Bookmaker> GetAsync(Guid Id)
            => await Task.FromResult(_bookmakers.Single(x => x.Id == Id));

        public async Task<IEnumerable<Bookmaker>> GetAllAsync()
            => await Task.FromResult(_bookmakers);

        public async Task RemoveAsync(Guid id)
        {
            var bukmacher = await GetAsync(id);
            _bookmakers.Remove(bukmacher);
            await Task.CompletedTask;
        }

        public async Task UpdateAsync(Guid id)
        {
            await Task.CompletedTask;
        }
    }
}

