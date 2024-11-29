using Microsoft.AspNetCore.Mvc;

namespace ValorantHubAPI.API.Services
{
    public class LoginService : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
