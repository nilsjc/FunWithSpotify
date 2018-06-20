using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using FunWithSpotifyApi.Authorization;
using FunWithSpotifyApi.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace FunWithSpotifyApi.Controllers
{
    public class AccountController : Controller
    {
        private const string UserName = "username";
        private const string PassWord = "password";

        private readonly AppSettings _appSettings;
        public AccountController(AppSettings appSettings)
        {
            _appSettings = appSettings;
        }
        
        [HttpPost]
        [Route("api/v1/login")]
        public async Task<IActionResult> Login([FromBody]LoginViewModel model)
        {
            var getTokenUrl = _appSettings.SpotifyAppConnectionString + "/" + Constants.TokenEndPoint;

            using (HttpClient httpClient = new HttpClient())
            {
                var content = new FormUrlEncodedContent(new[]
                {
                    new KeyValuePair<string, string>(UserName, model.UserName),
                    new KeyValuePair<string, string>(PassWord, model.Password)
                });

                var result = httpClient.PostAsync(getTokenUrl, content).Result;

                if (result.StatusCode != HttpStatusCode.OK)
                    return Unauthorized();

                string resultContent = result.Content.ReadAsStringAsync().Result;

                var token = JsonConvert.DeserializeObject<string>(resultContent);

                AuthenticationProperties options = new AuthenticationProperties();

                options.AllowRefresh = true;
                options.IsPersistent = true;
                options.ExpiresUtc = DateTime.UtcNow.AddMinutes(30);

                var claims = new[]
                {
                    new Claim(ClaimTypes.Name, model.UserName),
                    new Claim("AcessToken", $"Bearer {token}")
                };

                var identity = new ClaimsIdentity(claims, "ApplicationCookie");
                var authProperties = new AuthenticationProperties
                {
                    
                };
                await HttpContext.SignInAsync(
                    CookieAuthenticationDefaults.AuthenticationScheme, 
                    new ClaimsPrincipal(identity),
                    authProperties);
            }
            return Ok();
        }
        
    }
}
