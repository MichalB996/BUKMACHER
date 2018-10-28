using SportsBetting.Core.Domain;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SportsBetting.Core.Repositories
{
    public interface IUserRepository
    {
        Task<User> GetAsync(string email);
        Task<User> GetAsync(Guid Id);
        Task AddAsync(User user);
        Task RemoveAsync(Guid id);
        Task UpdateAsync(Guid id);
        Task<IEnumerable<User>> GetAllAsync();
    }
}
