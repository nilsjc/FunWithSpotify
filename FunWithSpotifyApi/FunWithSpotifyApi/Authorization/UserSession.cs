using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using FunWithSpotifyApi.Interfaces;
using Microsoft.AspNetCore.Http;

namespace FunWithSpotifyApi.Authorization
{
    public class UserSession : IUserSession
    {
        private readonly ClaimsPrincipal _claimsPrincipal;

        public UserSession(IHttpContextAccessor httpHttpContextAccessor)
        {
            _claimsPrincipal = httpHttpContextAccessor
                .HttpContext
                .User;
        }

        public string Username => _claimsPrincipal
            .FindFirstValue(ClaimTypes.Name);

        public string BearerToken => _claimsPrincipal
            .FindFirstValue(Constants.AccessToken);
    }
}
