using System;
using System.Collections.Generic;
using System.Text;
using BUKMACHER_CORE.Domain;
using BUKMACHER_CORE;
using BUKMACHER_CORE.Repositories;
using System.Linq;


namespace BUKMACHER_INFRASTRUCTURE.UserRepository
{
    public class InMemoryUserRepository : IUserRepository//BUKMACHER_CORE.Repositories.IUserRepository
    {
        private static ISet<User> _users = new HashSet<User>()
        {
            new User("mail1@gmail.com","nazwa1","dupa","salt"),
            new User("mail2@gmail.com","nazwa2","dupa","salt"),
            new User("mail3@gmail.com","nazwa3","dupa","salt")
        };
        public void Add(User user)
        {
            _users.Add(user);
        }

        public User Get(string email)
            => _users.Single(x => x.Email == email.ToLowerInvariant());

        public User Get(Guid Id)
            => _users.Single(x => x.Id == Id);

        public IEnumerable<User> GetAll()
            => _users;

        public void Remove(Guid id)
        {
            var user = Get(id);
            _users.Remove(user);
            
        }

        public void Update(Guid id)
        { }
    }
}
