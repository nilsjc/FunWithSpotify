using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using FunWithSpotifyApi.Interfaces;

namespace FunWithSpotifyApi.Services
{
    public class SpotifyApiClient : ISpotifyApiClient
    {
        private readonly HttpClient _client;

        public SpotifyApiClient(AppSettings appSettings)
        {
            _client = new HttpClient();
            _client.DefaultRequestHeaders.Accept.Clear();
        }

        public async Task<string> GetData(string query)
        {
            var result = await _client.GetStringAsync(query);
            return result;
        }
        private async Task<string> GetData(string query, string bearerToken)
        {
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", bearerToken);
            var result = await _client.GetStringAsync(query);
            return result;
        }

        async Task<string> ISpotifyApiClient.GetData(string query, string bearerToken)
        {
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", bearerToken);
            var result = await _client.GetStringAsync(query);
            return result;
        }

        private async Task PostData(string query)
        {
            
        }
    }
}
