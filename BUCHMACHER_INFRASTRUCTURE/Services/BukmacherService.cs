using AutoMapper;
using BUKMACHER_CORE.Domain;
using BUKMACHER_CORE.Repositories;
using BUKMACHER_INFRASTRUCTURE.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

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

        public async Task<BukmacherDTO> GetAsync(string email)
        {
            var bukmacher = await _bukmacherRepository.GetAsync(email);
            return _mapper.Map<Bukmacher, BukmacherDTO>(bukmacher);
        }

        public async Task RegisterAsync(string name)
        {
            var bukmacher = await _bukmacherRepository.GetAsync(name);
            if (bukmacher != null)
            {
                throw new Exception($"User with email: {name} already exists.");
            }
            var salt = Guid.NewGuid().ToString("N");
            bukmacher = Bukmacher.Create(name);
            await _bukmacherRepository.AddAsync(bukmacher);
            await Task.CompletedTask;
        }        
    }
}
