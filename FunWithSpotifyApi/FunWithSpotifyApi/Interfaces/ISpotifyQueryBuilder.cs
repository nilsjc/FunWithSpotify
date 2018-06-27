using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FunWithSpotifyApi.Interfaces
{
    public interface ISpotifyQueryBuilder
    {
        string GetAlbum(string id, string market);
    }
}
