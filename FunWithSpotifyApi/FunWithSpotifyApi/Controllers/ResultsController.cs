using System.Collections.Generic;
using FunWithSpotifyApi.Authorization;
using FunWithSpotifyApi.Helpers;
using FunWithSpotifyApi.Interfaces;
using FunWithSpotifyApi.Models;
using FunWithSpotifyApi.Models.SpotifyApi;
using Microsoft.AspNetCore.Mvc;

namespace FunWithSpotifyApi.Controllers
{
    public class ResultsController : Controller
    {
        private readonly ISpotifyApiClient _apiClient;
        private readonly ISpotifyQueryBuilder _queryBuilder;
        private readonly IRecommendationBuilder _recommendationBuilder;
        private readonly string _clientId;
        private readonly string _clientSecret;

        public ResultsController(AppSettings appSettings, ISpotifyApiClient apiClient, ISpotifyQueryBuilder queryBuilder, 
            IRecommendationBuilder recommendationBuilder)
        {
            _clientId = appSettings.ClientId;
            _clientSecret = appSettings.ClientSecret;
            _apiClient = apiClient;
            _queryBuilder = queryBuilder;
            _recommendationBuilder = recommendationBuilder;
        }

        
        public IActionResult Index(string result)
        {
                var answers = JsonHelp.Deserialize<List<Answer>>(result);
                var model = GetTracks(answers);
                return View(model);
        }

        private TrackList GetTracks(List<Answer>answers)
        {
            var recommendation = _recommendationBuilder.CalculateFromQuestions(answers);

            var query = _queryBuilder.GetRecommendations(recommendation);
            var result = _apiClient.GetData(query,
                AuthTokenGenerator
                    .DoAuth(_clientId, _clientSecret)
                    .AccessToken).Result;

            var tracks = JsonHelp.Deserialize<TrackList>(result);
            return tracks;
        }
    }
}