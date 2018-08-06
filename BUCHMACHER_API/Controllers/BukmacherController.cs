using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BUKMACHER_INFRASTRUCTURE.DTO;
using BUKMACHER_INFRASTRUCTURE.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BUKMACHER_API.Controllers
{
    //[Produces("application/json")]
    [Route("[controller]")]
    public class BukmacherController : Controller
    {
        private readonly IBukmacherService _bukmacherService;
        public BukmacherController(IBukmacherService bukmacherService)
        {
            _bukmacherService = bukmacherService;
        }
        [HttpGet("{name}")]
        public BukmacherDTO Get(string name)
            => _bukmacherService.Get(name);
    }
}
