using SportsBetting.Api;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Newtonsoft.Json;
using SportsBetting.Infrastructure.DTO;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;


namespace SportsBetting.EndToEnd.Controllers
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

