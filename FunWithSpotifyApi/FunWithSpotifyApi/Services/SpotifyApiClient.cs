using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using FunWithSpotifyApi.Interfaces;

namespace FunWithSpotifyApi.Services
{
    public class SpotifyApiClient : ISpotifyApiClient
    {
        private readonly HttpClient _client;
        private const string Bearer = "Bearer";

        public SpotifyApiClient(AppSettings appSettings)
        {
            _client = new HttpClient();
            _client.DefaultRequestHeaders.Accept.Clear();
        }

        public async Task<string> GetData(string query, string bearerToken)
        {
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(Bearer, bearerToken);
            var result = await _client.GetStringAsync(query);
            return result;
        }
    }
}
