using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;

namespace FunWithSpotifyApi.Interfaces
{
    public interface IGetBearerToken
    {
        JwtSecurityToken Get(string userName, string password);
    }
}
