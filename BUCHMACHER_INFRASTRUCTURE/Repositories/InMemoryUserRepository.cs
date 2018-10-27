using SportsBetting.Core.Domain;
using SportsBetting.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportsBetting.Infrastructure.UserRepository
{
    public class InMemoryUserRepository : IUserRepository
    {
        private static ISet<User> _users = new HashSet<User>()
        {
            new User("mail1@mail.com","name1","password1","salt1"),
            new User("mail2@mail.com","name2","password2","salt2"),
            new User("mail3@mail.com","name3","password3","salt3"),
            new User("mail4@mail.com","name4","password4","salt4")
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
