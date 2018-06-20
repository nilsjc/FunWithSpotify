using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FunWithSpotifyApi.Interfaces
{
    public interface IUserSession
    {
        string Username { get; }
        string BearerToken { get; }
    }
}
