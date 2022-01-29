using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using project.domain.Entities;
using project.repository.Interfaces;
using System.Net.Http;
using System.Threading.Tasks;

namespace project.repository.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly HttpClient _httpClient;
        private readonly string AUTHAPI;

        public UsuarioRepository(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            AUTHAPI = configuration.GetSection("AUTHAPI").Value;
        }

        public async Task<Autenticacao> login(Usuario usuario)
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

            return new Autenticacao { success = true };
        }
    }
}
