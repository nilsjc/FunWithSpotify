using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace FunWithSpotifyApi.Models.SpotifyApi
{
    public class TrackList
    {
        [JsonProperty("tracks")]
        public List<Track> Tracks { get; set; }

        public TrackList()
        {
            Tracks = new List<Track>();
        }
    }
}
