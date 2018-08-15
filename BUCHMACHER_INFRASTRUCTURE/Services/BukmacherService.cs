using AutoMapper;
using BUKMACHER_CORE.Domain;
using BUKMACHER_CORE.Repositories;
using BUKMACHER_INFRASTRUCTURE.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace BUKMACHER_INFRASTRUCTURE.Services
{
    public class BukmacherService : IBukmacherService
    {
        private readonly IBukmacherRepository _bukmacherRepository;
        private readonly IMapper _mapper;
        public BukmacherService(IBukmacherRepository bukmacherRepository, IMapper mapper)
        {
            _bukmacherRepository = bukmacherRepository;
            _mapper = mapper;
        }

        public BukmacherDTO Get(string email)
        {
            var bukmacher = _bukmacherRepository.Get(email);
            return _mapper.Map<Bukmacher, BukmacherDTO>(bukmacher);
        }

        public void Register(string name)
        {
            var bukmacher = _bukmacherRepository.Get(name);
            if (bukmacher != null)
            {
                throw new Exception($"User with email: {name} already exists.");
            }
            var salt = Guid.NewGuid().ToString("N");
            bukmacher = Bukmacher.Create(name);
            _bukmacherRepository.Add(bukmacher);
        }

        
    }
}
