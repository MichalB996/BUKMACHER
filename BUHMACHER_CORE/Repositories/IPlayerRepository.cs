using BUKMACHER_CORE.Domain;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BUKMACHER_CORE.Repositories
{
    public interface IPlayerRepository
    {
        // wzorzec CQS - Command Query Separation -  metody osobno do odczytu osobno do tworzenia
        // wzorzec Repository- wzorzec, mówiący o tym, gdzie dane są przechowywane
        // agregate root - typ, który zawiera w sobie dane, które mają sens do pobrania
        Task<Player> GetAsync(string email);
        Task<Player> GetAsync(Guid Id);
        Task AddAsync(Player user);
        Task RemoveAsync(Guid id);
        Task UpdateAsync(Guid id);
        Task<IEnumerable<Player>> GetAllAsync();
    }
}
