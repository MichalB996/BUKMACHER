using BUKMACHER_CORE.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace BUKMACHER_CORE.Repositories
{
    public interface IUserRepository
    {
        // wzorzec CQS - Command Query Separation -  metody osobno do odczytu osobno do tworzenia
        // wzorzec Repository- wzorzec, mówiący o tym, gdzie dane są przechowywane
        // agregate root - typ, który zawiera w sobie dane, które mają sens do pobrania
        User Get(string email);
        User Get(Guid Id);
        void Add(User user);
        void Remove(Guid id);
        void Update(Guid id);
        IEnumerable<User> GetAll();
    }
}
