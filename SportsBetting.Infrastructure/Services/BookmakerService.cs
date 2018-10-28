using AutoMapper;
using SportsBetting.Core.Domain;
using SportsBetting.Core.Repositories;
using SportsBetting.Infrastructure.DTO;
using System;
using System.Threading.Tasks;

namespace SportsBetting.Infrastructure.Services
{
    public class BookmakerService : IBookmakerService
    {
        private readonly IBookmakerRepository _bookmakerRepository;
        private readonly IMapper _mapper;
        public BookmakerService(IBookmakerRepository bookmakerRepository, IMapper mapper)
        {
            _bookmakerRepository = bookmakerRepository;
            _mapper = mapper;
        }

        public async Task<BookmakerDTO> GetAsync(string email)
        {
            var bookmaker = await _bookmakerRepository.GetAsync(email);
            return _mapper.Map<Bookmaker, BookmakerDTO>(bookmaker);
        }

        public async Task RegisterAsync(string name)
        {
            var SportsBetting = await _bookmakerRepository.GetAsync(name);
            if (SportsBetting != null)
            {
                throw new Exception($"User with email: {name} already exists.");
            }
            var salt = Guid.NewGuid().ToString("N");
            SportsBetting = Bookmaker.Create(name);
            await _bookmakerRepository.AddAsync(SportsBetting);
            await Task.CompletedTask;
        }        
    }
}
