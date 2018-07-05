using System.Text;
using FunWithSpotifyApi.Interfaces;
using FunWithSpotifyApi.Models;

namespace FunWithSpotifyApi.Services
{
    public class SpotifyQueryBuilder : ISpotifyQueryBuilder
    {
        private const string ApiUrl = "https://api.spotify.com/v1";
        private const string Market = "market";
        private const string Albums = "albums";
        

        #region Albums
        
        public string GetAlbum(string id, string market = "")
        {
            if (string.IsNullOrEmpty(market))
                return $"{ApiUrl}/{Albums}/{id}";
            return $"{ApiUrl}/{Albums}/{id}?{Market}={market}";
        }
        
        #endregion Albums

        #region Browse
            
        public string GetCategory(string categoryId, string country = "", string locale = "")
        {
            StringBuilder builder = new StringBuilder(ApiUrl + "/browse/categories/" + categoryId);
            if (!string.IsNullOrEmpty(country))
                builder.Append("?country=" + country);
            if (!string.IsNullOrEmpty(locale))
                builder.Append((country == "" ? "?locale=" : "&locale=") + locale);
            return builder.ToString();
        }



        public string GetRecommendations(RecommendationModel rec)
        {
            var builder = new StringBuilder($"{ApiUrl}/recommendations");
            builder.Append("?limit=" + rec.Limit);

            if (rec.ArtistSeed?.Count > 0)
                builder.Append("&seed_artists=" + string.Join(",", rec.ArtistSeed));

            if (rec.GenreSeed?.Count > 0)
                builder.Append("&seed_genres=" + string.Join(",", rec.GenreSeed));

            if (rec.TrackSeed?.Count > 0)
                builder.Append("&seed_tracks=" + string.Join(",", rec.TrackSeed));

            if (rec.Target != null)
                builder.Append(rec.Target.BuildUrlParams("target"));

            if (rec.Min != null)
                builder.Append(rec.Min.BuildUrlParams("min"));

            if (rec.Max != null)
                builder.Append(rec.Max.BuildUrlParams("max"));

            if (!string.IsNullOrEmpty(rec.Market))
                builder.Append("&market=" + rec.Market);

            return builder.ToString();
        }

        #endregion Browse

        
}
}
