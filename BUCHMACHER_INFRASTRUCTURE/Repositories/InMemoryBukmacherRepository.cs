using BUKMACHER_CORE.Domain;
using BUKMACHER_CORE.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUKMACHER_INFRASTRUCTURE.Repositories
{
    public class InMemoryBukmacherRepository : IBukmacherRepository
    {
        private static ISet<Bukmacher> _bukmachers = new HashSet<Bukmacher>()
        {
            Bukmacher.Create("Fic")
        };

        public async Task AddAsync(Bukmacher bukmacher)
        {
            _bukmachers.Add(bukmacher);
        }

        public async Task<Bukmacher> GetAsync(string bukmachername)
            => await Task.FromResult(_bukmachers.Single(x => x.BukmacherName == bukmachername));

        public async Task<Bukmacher> GetAsync(Guid Id)
        => await Task.FromResult(_bukmachers.Single(x => x.Id == Id));

        public async Task<IEnumerable<Bukmacher>> GetAllAsync()
        => await Task.FromResult(_bukmachers);

        public async Task RemoveAsync(Guid id)
        {
            var bukmacher = await GetAsync(id);
            _bukmachers.Remove(bukmacher);
            await Task.CompletedTask;
        }

        public async Task UpdateAsync(Guid id)
        {
            await Task.CompletedTask;
        }
    }
}

