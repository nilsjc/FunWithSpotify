using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using FunWithSpotifyApi.Interfaces;
using Newtonsoft.Json;

namespace FunWithSpotifyApi.Services
{
    public class SpotifyQueryBuilder : ISpotifyQueryBuilder
    {
        private const string AuthUrl = "https://accounts.spotify.com/api/token";
        private const string ApiUrl = "https://api.spotify.com/v1";
        private const string Limit = "limit";
        private const string Offset = "offset";
        private const string Market = "market";
        private const string Albums = "albums";

        private const int CategoriesLimit = 10;
        private const int TracksLimit = 50;

        #region Albums
        public string GetAlbumTracks(string id, int limit = 20, int offset = 0, string market = "")
        {
            limit = Math.Min(limit, 50);
            var builder = new StringBuilder(ApiUrl + "/" + Albums +"/" + id + "/tracks");
            builder.Append("?" + Limit + "=" + limit);
            builder.Append("&" + Offset + "=" + offset);
            if (!string.IsNullOrEmpty(market))
                builder.Append("&" + Market + "=" + market);
            return builder.ToString();
        }

        public string GetAlbum(string id, string market = "")
        {
            if (string.IsNullOrEmpty(market))
                return $"{ApiUrl}/{Albums}/{id}";
            return $"{ApiUrl}/{Albums}/{id}?{Market}={market}";
        }

        public string GetSeveralAlbums(List<string> ids, string market = "")
        {
            if (string.IsNullOrEmpty(market))
                return $"{ApiUrl}/albums?ids={string.Join(",", ids.Take(20))}";
            return $"{ApiUrl}/albums?market={market}&ids={string.Join(",", ids.Take(20))}";
        }

        #endregion Albums

        #region Browse
        
        public string GetCategories(string country = "", string locale = "", int limit = CategoriesLimit, int offset = 0)
        {
            limit = Math.Min(50, limit);
            var builder = new StringBuilder(ApiUrl + "/browse/categories");
            builder.Append("?limit=" + limit);
            builder.Append("&offset=" + offset);
            if (!string.IsNullOrEmpty(country))
                builder.Append("&country=" + country);
            if (!string.IsNullOrEmpty(locale))
                builder.Append("&locale=" + locale);
            return builder.ToString();
        }

        public string GetCategory(string categoryId, string country = "", string locale = "")
        {
            StringBuilder builder = new StringBuilder(ApiUrl + "/browse/categories/" + categoryId);
            if (!string.IsNullOrEmpty(country))
                builder.Append("?country=" + country);
            if (!string.IsNullOrEmpty(locale))
                builder.Append((country == "" ? "?locale=" : "&locale=") + locale);
            return builder.ToString();
        }

        public string GetCategoryPlaylists(string categoryId, string country = "", int limit = 20, int offset = 0)
        {
            limit = Math.Min(50, limit);
            var builder = new StringBuilder(ApiUrl + "/browse/categories/" + categoryId + "/playlists");
            builder.Append("?limit=" + limit);
            builder.Append("&offset=" + offset);
            if (!string.IsNullOrEmpty(country))
                builder.Append("&country=" + country);
            return builder.ToString();
        }

        #endregion Browse

        #region Playlists

        public string GetPlaylist(string userId, string playlistId, string fields = "", string market = "")
        {
            var builder = new StringBuilder(ApiUrl + "/users/" + userId + "/playlists/" + playlistId);
            builder.Append("?fields=" + fields);
            if (!string.IsNullOrEmpty(market))
                builder.Append("&market=" + market);
            return builder.ToString();
        }

        public string GetPlaylistTracks(string userId, string playlistId, string fields = "", int limit = TracksLimit, int offset = 0, string market = "")
        {
            limit = Math.Min(limit, 100);
            var builder = new StringBuilder(ApiUrl + "/users/" + userId + "/playlists/" + playlistId + "/tracks");
            builder.Append("?fields=" + fields);
            builder.Append("&limit=" + limit);
            builder.Append("&offset=" + offset);
            if (!string.IsNullOrEmpty(market))
                builder.Append("&market=" + market);
            return builder.ToString();
        }

        #endregion Playlists
    }
}
