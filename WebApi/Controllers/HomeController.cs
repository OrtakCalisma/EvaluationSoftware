using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
    }
}
