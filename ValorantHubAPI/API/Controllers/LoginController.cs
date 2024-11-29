using Microsoft.AspNetCore.Mvc;

namespace ValorantHubAPI.API.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
