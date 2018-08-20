using System;
using System.Collections.Generic;
using System.Text;
using BUKMACHER_CORE.Domain;
using BUKMACHER_CORE;
using BUKMACHER_CORE.Repositories;
using System.Linq;
using System.Threading.Tasks;

namespace BUKMACHER_INFRASTRUCTURE.UserRepository
{
    public class InMemoryUserRepository : IUserRepository//BUKMACHER_CORE.Repositories.IUserRepository
    {
        private static ISet<User> _users = new HashSet<User>()
        {
            new User("mail1@gmail.com","nazwa1","dupa","salt"),
            new User("mail2@gmail.com","nazwa2","dupa","salt"),
            new User("sebek1113@gmail.com","ChujCiWDupie","ehehehe","salt"),
            new User("oktawia.sepiol@gmail.com","OktawiaKochaMichala","haslo123","salt")
        };
        public async Task AddAsync(User user)
        {
            _users.Add(user);
            await Task.CompletedTask;
        }

        public async Task<User> GetAsync(string email)
            => await Task.FromResult(_users.SingleOrDefault(x => x.Email == email.ToLowerInvariant()));

        public async Task<User> GetAsync(Guid Id)
            => await Task.FromResult(_users.SingleOrDefault(x => x.Id == Id));

        public async Task<IEnumerable<User>> GetAllAsync()
            => await Task.FromResult(_users);

        public async Task RemoveAsync(Guid id)
        {
            var user = await GetAsync(id);
            _users.Remove(user);
            await Task.CompletedTask;
            
        }

        public async Task UpdateAsync(Guid id)
        {
            await Task.CompletedTask;
        }
    }
}
