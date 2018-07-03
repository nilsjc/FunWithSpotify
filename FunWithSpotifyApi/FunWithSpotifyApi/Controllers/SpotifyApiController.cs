using System.Collections.Generic;
using System.IO;
using FunWithSpotifyApi.Authorization;
using FunWithSpotifyApi.Interfaces;
using FunWithSpotifyApi.Models.SpotifyApi;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace FunWithSpotifyApi.Controllers
{
    public class SpotifyApiController : Controller
    {
        private readonly ISpotifyApiClient _apiClient;
        private readonly ISpotifyQueryBuilder _queryBuilder;
        private readonly string ClientId;
        private readonly string ClientSecret;

        public SpotifyApiController(AppSettings appSettings, ISpotifyApiClient apiClient, ISpotifyQueryBuilder queryBuilder)
        {
            ClientId = appSettings.ClientId;
            ClientSecret = appSettings.ClientSecret;
            _apiClient = apiClient;
            _queryBuilder = queryBuilder;
            
        }

        public IActionResult Albums()
        {
            var result = GetAlbums("4aawyAB9vmqN3uQ7FjRGTy","ES");
            return View(result);
        }



        public IActionResult Tracks()
        {
            return View();
        }
        private List<Album> GetAlbums(string id, string market)
        {
            var authToken =
                AuthTokenGenerator.DoAuth(ClientId, ClientSecret);

            var query = _queryBuilder.GetAlbum(id, market);
            var result = _apiClient.GetData(query,authToken.AccessToken).Result;
            var album = Deserialize<Album>(result);
            var albums = new List<Album>
            {
                album
            };
            return albums;
            //albums.AddRange(album);
        }

        private List<Track> GetTracks()
        {
            var tracks = new List<Track>();
            return tracks;
        }

        private T Deserialize<T>(string json)
        {
            JsonSerializer s = new JsonSerializer();
            return s.Deserialize<T>(new JsonTextReader(new StringReader(json)));
        }
    }
}