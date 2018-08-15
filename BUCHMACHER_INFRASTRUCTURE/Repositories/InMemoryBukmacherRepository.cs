using BUKMACHER_CORE.Domain;
using BUKMACHER_CORE.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BUKMACHER_INFRASTRUCTURE.Repositories
{
    public class InMemoryBukmacherRepository : IBukmacherRepository
    {
        private static ISet<Bukmacher> _bukmachers = new HashSet<Bukmacher>()
        {
            Bukmacher.Create("Fic")
        };

        public void Add(Bukmacher bukmacher)
        {
            _bukmachers.Add(bukmacher);
        }

        public Bukmacher Get(string bukmachername)
            => _bukmachers.Single(x => x.BukmacherName == bukmachername);
        //=> _bukmachers.Single(x => x.BukmacherName == bukmachername.ToLowerInvariant());

        public Bukmacher Get(Guid Id)
        => _bukmachers.Single(x => x.Id == Id);

        public IEnumerable<Bukmacher> GetAll()
        => _bukmachers;

        public void Remove(Guid id)
        {
            var bukmacher = Get(id);
            _bukmachers.Remove(bukmacher);
        }

        public void Update(Guid id)
        {}
       
    }
}

