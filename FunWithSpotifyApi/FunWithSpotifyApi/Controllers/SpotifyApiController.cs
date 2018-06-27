using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Runtime.Serialization.Json;
using System.Threading.Tasks;
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

        public SpotifyApiController(AppSettings appSettings, ISpotifyApiClient apiClient, ISpotifyQueryBuilder queryBuilder)
        {
            _apiClient = apiClient;
            _queryBuilder = queryBuilder;
        }
        
        public IActionResult GetAlbum(/*string id, string market*/)
        {
            var albumForFun = new Album();
            var ser = new DataContractJsonSerializer(albumForFun.GetType());

            var id = "4aawyAB9vmqN3uQ7FjRGTy";
            var market = "ES";
            var authToken =
                "BQA0FiPJUpR5WPmLhyeyUwa_ayfnQfgGS9Ds-J_fanXl7pUjyq5j_wSxpn8QDZCEBMBAoG6ymCnrVMa0UDY7X4nmlgYfXD_kniPIpWY3TXIPgPakaE-hUwxqC4oWxO5h_tTZvw";
            var query = _queryBuilder.GetAlbum(id, market);
            var result = _apiClient.GetData(query,authToken);
            var album = (Album) ser.ReadObject(result);
            return Ok(result);
        }
    }
}