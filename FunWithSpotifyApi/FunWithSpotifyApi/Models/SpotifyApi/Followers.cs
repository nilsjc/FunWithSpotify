using Newtonsoft.Json;

namespace FunWithSpotifyApi.Models.SpotifyApi
{
    public class Followers
    {
        [JsonProperty("href")]
        public string Href { get; set; }

        [JsonProperty("total")]
        public int Total { get; set; }
    }
}
