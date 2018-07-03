using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using FunWithSpotifyApi.Interfaces;
using FunWithSpotifyApi.Models;
using Newtonsoft.Json;

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
