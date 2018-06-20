using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using FunWithSpotifyApi.Models.SpotifyApi;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace FunWithSpotifyApi.Controllers
{
    public class SpotifyApiController : Controller
    {
        private readonly AppSettings _appSettings;

        public SpotifyApiController(AppSettings appSettings)
        {
            _appSettings = appSettings;
        }
    }
}
