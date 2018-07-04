using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace FunWithSpotifyApi.Models
{
    public class Answer
    {
        [JsonProperty("id")]
        public string Id { get; set; }
        [JsonProperty("value")]
        public string Value { get; set; }
    }
}
