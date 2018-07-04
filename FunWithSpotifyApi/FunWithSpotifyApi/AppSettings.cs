using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FunWithSpotifyApi
{
    public class AppSettings
    {
        public string SpotifyAppConnectionString { get; set; }
        public string ClientId { get; set; }
        public string ClientSecret { get; set; }
        public string Region { get; set; }
    }
}
