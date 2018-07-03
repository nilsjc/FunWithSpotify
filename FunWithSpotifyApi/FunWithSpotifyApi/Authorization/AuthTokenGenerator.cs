using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using FunWithSpotifyApi.Models;
using Newtonsoft.Json;

namespace FunWithSpotifyApi.Authorization
{
    public static class AuthTokenGenerator
    {
        private const string AuthUrl = "https://accounts.spotify.com/api/token";
        private const string Post = "POST";
        private const string Authorization = "Authorization";
        private const string Basic = "Basic ";

        private static readonly NameValueCollection col = 
            new NameValueCollection
            {
                {"grant_type", "client_credentials"}
            };

        public static Token DoAuth(string clientId, string clientSecret)
        {
            using (var wc = new WebClient())
            {
                wc.Headers.Add(Authorization,
                    Basic + Convert.ToBase64String(Encoding.UTF8.GetBytes(clientId + ":" + clientSecret)));
                
                byte[] data;
                try
                {
                    data = wc.UploadValues(AuthUrl, Post, col);
                }
                catch (WebException e)
                {
                    using (StreamReader reader = new StreamReader(e.Response.GetResponseStream() ?? throw new InvalidOperationException()))
                    {
                        data = Encoding.UTF8.GetBytes(reader.ReadToEnd());
                    }
                }
                return JsonConvert.DeserializeObject<Token>(Encoding.UTF8.GetString(data));
            }
        }
    }
}
