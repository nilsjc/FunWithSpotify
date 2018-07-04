using System.Collections.Generic;
using FunWithSpotifyApi.Models.SpotifyApi;

namespace FunWithSpotifyApi.Models
{
    public class RecommendationModel
    {
        public List<string> ArtistSeed { get; set; }
        public List<string> GenreSeed { get; set; }
        public List<string> TrackSeed { get; set; }
        public TunableTrack Target { get; set; }
        public TunableTrack Min {get; set; }
        public TunableTrack Max { get; set; }
        public int Limit { get; set; }
        public string Market { get; set; }

        public RecommendationModel()
        {
            Limit = 20;
        }
    }
}
