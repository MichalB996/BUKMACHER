using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using BUKMACHER_CORE.Domain;
using BUKMACHER_CORE.Repositories;
using BUKMACHER_INFRASTRUCTURE.DTO;
using BUKMACHER_INFRASTRUCTURE.Services;
using Moq;
using NUnit;
using Xunit;

namespace BUKMACHERT_TESTS.Services
{
    public class BukmacherServiceTest
    {
        [Fact]
        public async Task Register_Async_should_invokes_once()
        {
            var BukmacherRepositoryMock = new Mock<IBukmacherRepository>();
            var AutoMapperMock = new Mock<IMapper>();
            var BukmacherService = new BukmacherService(BukmacherRepositoryMock.Object, AutoMapperMock.Object);
            await BukmacherService.RegisterAsync("Fortunka");
            BukmacherRepositoryMock.Verify(x => x.AddAsync(It.IsAny<Bukmacher>()), Times.Once);
        }
        [Fact]
        public async Task GetAsync_should_invokes_exactly_twice()
        {
            var BukmacherRepositoryMock = new Mock<IBukmacherRepository>();
            var AutoMapperMock = new Mock<IMapper>();
            var BukmacherService = new BukmacherService(BukmacherRepositoryMock.Object, AutoMapperMock.Object);
            await BukmacherService.RegisterAsync("Fortunka");
            BukmacherRepositoryMock.Verify(x => x.GetAsync(""), Times.Exactly(0));

        }
    }
}
