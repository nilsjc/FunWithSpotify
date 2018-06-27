using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FunWithSpotifyApi.Interfaces
{
    public interface ISpotifyApiClient
    {
        Task<string> GetData(string query);
        Task<string> GetData(string query, string bearerToken);
    }
}
