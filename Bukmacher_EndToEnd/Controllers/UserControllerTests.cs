using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using BUCHMACHER_API;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Xunit;
using Newtonsoft.Json;
using BUKMACHER_INFRASTRUCTURE.DTO;
using System.Threading;
using NUnit;
using Moq;
using BUKMACHER_CORE.Repositories;
using BUKMACHER_INFRASTRUCTURE.Services;
using AutoMapper;
using BUKMACHER_CORE.Domain;
using Microsoft.Net;
using Acheve.AspNetCore.TestHost;
using Acheve.TestHost;


namespace Bukmacher_EndToEnd.Controllers
{
    public class UserControllerTests
    {
        protected readonly TestServer Server;
        protected readonly HttpClient Client;

        public UserControllerTests()
        {
            Server = new TestServer(new WebHostBuilder()
                          .UseStartup<Startup>());
            Client = Server.CreateClient();
        }
        [Fact]
        public async Task given_invalid_email_user_should_exists()
        {
            var email = "user1@email.com";
            var response = await Client.GetAsync($"users/{email}");
            response.EnsureSuccessStatusCode();
            var responseString = await response.Content.ReadAsStringAsync();
            var user = JsonConvert.DeserializeObject<UserDTO>(responseString);
        }
    }
}

