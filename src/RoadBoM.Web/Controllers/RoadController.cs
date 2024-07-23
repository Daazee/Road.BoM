using Microsoft.AspNetCore.Mvc;

namespace RoadBoM.Web.Controllers
{
    public class RoadController : Controller
    {
        public IActionResult AllRoads()
        {
            return View();
        }
        public IActionResult Register()
        {
            return View();
        }
    }
}
