using Microsoft.Extensions.Configuration;
using project.domain.Entities;
using project.domain.Interfaces.Repositories;
using System.Net.Http;
using System.Threading.Tasks;

namespace project.data.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly HttpClient _httpClient;
        private readonly string AUTHAPI;

        public UserRepository(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            AUTHAPI = configuration.GetSection("AUTHAPI").Value;
        }

#pragma warning disable CS1998 // Async method lacks 'await' operators and will run synchronously
        public async Task<User> Login(string username, string password)
#pragma warning restore CS1998 // Async method lacks 'await' operators and will run synchronously
        {
            //var autenticacao = usuario.BasicAutentication();

            //_httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", autenticacao);

            //var response = await _httpClient.PostAsync(AUTHAPI, new StringContent(""));

            //var settings = new JsonSerializerSettings
            //{
            //    NullValueHandling = NullValueHandling.Ignore,
            //    MissingMemberHandling = MissingMemberHandling.Ignore
            //};

            //var auth = JsonConvert.DeserializeObject<Autenticacao>(await response.Content.ReadAsStringAsync(), settings);

            return new User(username, password);
        }
    }
}
