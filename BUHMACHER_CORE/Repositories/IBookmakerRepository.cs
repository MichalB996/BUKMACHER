using SportsBetting.Core.Domain;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SportsBetting.Core.Repositories
{
    public interface IBookmakerRepository
    {
        Task<Bookmaker> GetAsync(string email);
        Task<Bookmaker> GetAsync(Guid Id);
        Task AddAsync(Bookmaker user);
        Task RemoveAsync(Guid id);
        Task UpdateAsync(Guid id);
        Task<IEnumerable<Bookmaker>> GetAllAsync();
    }
}
