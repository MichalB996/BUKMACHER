using BUKMACHER_CORE.Domain;
using BUKMACHER_CORE.Repositories;
using BUKMACHER_INFRASTRUCTURE.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace BUKMACHER_INFRASTRUCTURE.Services
{
    class BukmacherService : IBukmacherService
    {
        private readonly IBukmacherRepository _bukmacherRepository;
        public BukmacherService(IBukmacherRepository bukmacherRepository)
        {
            _bukmacherRepository = bukmacherRepository;
        }

        public BukmacherDTO Get(string email)
        {
            var bukmacher = _bukmacherRepository.Get(email);
            return new BukmacherDTO
            {
                BukmacherName = bukmacher.BukmacherName,
                Id = bukmacher.Id

            };
        }

        public void Register(string name)
        {
            var bukmacher = _bukmacherRepository.Get(name);
            if (bukmacher != null)
            {
                throw new Exception($"User with email: {name} already exists.");
            }
            var salt = Guid.NewGuid().ToString("N");
            bukmacher = new Bukmacher(name);
            _bukmacherRepository.Add(bukmacher);
        }

        
    }
}
