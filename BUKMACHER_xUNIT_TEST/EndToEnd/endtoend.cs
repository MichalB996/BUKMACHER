using BUCHMACHER_API;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Newtonsoft.Json;
using SportsBetting.Infrastructure.Commands.User;
using SportsBetting.Infrastructure.DTO;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace SportsBetting.Test.EndtoEnd.EndToEnd
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
            Assert.Equal(response.StatusCode, HttpStatusCode.NotFound);
        }

        [Fact]
        public async Task given_unique_email_user_should_be_created()
        {
            var request = new CreateUser
            {
                Email = "email10@gmail.com",
                Username = "dupa",
                Password = "heszkewmeszke"
            };
            var payload = GetPayLoad(request);

            var response = await Client.PostAsync("User", payload);
            response.StatusCode.Equals(HttpStatusCode.Created);
            response.Headers.ToString().Equals($"User/{request.Email}");
        }
        [Fact]
        public async Task given_Valid_password_should_be_change()
        {
            var request = new ChangeUserPassword
            {
                CurrentPassword = "secret",
                NewPassword = "secret2"
            };
            var payload = GetPayLoad(request);

            var response = await Client.PutAsync("password", payload);
            response.StatusCode.Equals(HttpStatusCode.NoContent);
        }

        public static StringContent GetPayLoad(object data)
        {
            var json = JsonConvert.SerializeObject(data);
            return new StringContent(json, Encoding.UTF8, "application/json");
        } 
    }
}
