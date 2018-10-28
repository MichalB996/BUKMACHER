using AutoMapper;
using Moq;
using SportsBetting.Core.Domain;
using SportsBetting.Core.Repositories;
using SportsBetting.Infrastructure.Services;
using System.Threading.Tasks;
using Xunit;

namespace SportsBetting.Test.EndtoEnd.Services
{
    public class BookmakerServiceTest
    {
        [Fact]
        public async Task Register_Async_should_invokes_once()
        {
            var BukmacherRepositoryMock = new Mock<IBookmakerRepository>();
            var AutoMapperMock = new Mock<IMapper>();
            var BukmacherService = new BookmakerService(BukmacherRepositoryMock.Object, AutoMapperMock.Object);
            await BukmacherService.RegisterAsync("Fortunka");
            BukmacherRepositoryMock.Verify(x => x.AddAsync(It.IsAny<Bookmaker>()), Times.Once);
        }
        [Fact]
        public async Task GetAsync_should_invokes_exactly_twice()
        {
            var BukmacherRepositoryMock = new Mock<IBookmakerRepository>();
            var AutoMapperMock = new Mock<IMapper>();
            var BukmacherService = new BookmakerService(BukmacherRepositoryMock.Object, AutoMapperMock.Object);
            await BukmacherService.RegisterAsync("Fortunka");
            BukmacherRepositoryMock.Verify(x => x.GetAsync(""), Times.Exactly(0));

        }
    }
}
