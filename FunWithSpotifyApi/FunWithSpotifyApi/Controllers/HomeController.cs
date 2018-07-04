using Microsoft.AspNetCore.Mvc;

namespace FunWithSpotifyApi.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
