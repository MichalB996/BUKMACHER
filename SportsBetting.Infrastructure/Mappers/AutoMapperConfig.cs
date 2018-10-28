using AutoMapper;
using SportsBetting.Core.Domain;
using SportsBetting.Infrastructure.DTO;

namespace SportsBetting.Infrastructure.Mappers
{
    public static class AutoMapperConfig
    {
        public static IMapper Initialize()
            => new MapperConfiguration(cfg => {
                cfg.CreateMap<User, UserDTO>();
                cfg.CreateMap<Bookmaker, BookmakerDTO>();
                }
                ).CreateMapper();
    }
}
