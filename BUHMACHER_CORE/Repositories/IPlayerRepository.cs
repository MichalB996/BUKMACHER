using BUKMACHER_CORE.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace BUKMACHER_CORE.Repositories
{
    public interface IPlayerRepository
    {
        // wzorzec CQS - Command Query Separation -  metody osobno do odczytu osobno do tworzenia
        // wzorzec Repository- wzorzec, mówiący o tym, gdzie dane są przechowywane
        // agregate root - typ, który zawiera w sobie dane, które mają sens do pobrania
        Player Get(string email);
        Player Get(Guid Id);
        void Add(Player user);
        void Remove(Guid id);
        void Update(Guid id);
        IEnumerable<Player> GetAll();
    }
}
