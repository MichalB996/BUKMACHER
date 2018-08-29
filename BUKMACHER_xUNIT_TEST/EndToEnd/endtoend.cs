using BUCHMACHER_API;
using BUKMACHER_CORE.Domain;
using BUKMACHER_INFRASTRUCTURE.DTO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace BUKMACHERT_TESTS.EndToEnd
{
    public class EndToEnd
    {
        protected readonly TestServer Server;
        protected readonly HttpClient Client;

        public EndToEnd()
        {
            Server = new TestServer(new WebHostBuilder()
                          .UseStartup<Startup>());
            Client = Server.CreateClient();
        }

        [Fact]
        public async Task given_valid_email_user_should_exists()
        {
            var email = "mail1@gmail.com";
            var response = await Client.GetAsync($"User/{email}");
            response.EnsureSuccessStatusCode();
            var responseString = await response.Content.ReadAsStringAsync();
            var user = JsonConvert.DeserializeObject<UserDTO>(responseString);
            Assert.Equal(email, user.Email);
        }
        [Fact]
        public async Task given_invalid_email_user_should_not_exists()
        {
            var email = "mail100@gmail.com";
            var response = await Client.GetAsync($"User/{email}");
            response.EnsureSuccessStatusCode();
            var responseString = await response.Content.ReadAsStringAsync();
            var user = JsonConvert.DeserializeObject<UserDTO>(responseString);
            Assert.NotEqual(email, user.Email);
        }
    }
}
