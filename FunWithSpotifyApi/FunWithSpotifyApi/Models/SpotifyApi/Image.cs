using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace FunWithSpotifyApi.Models.SpotifyApi
{
    public class Image
    {
        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonProperty("width")]
        public int Width { get; set; }

        [JsonProperty("height")]
        public int Height { get; set; }
    }
}
