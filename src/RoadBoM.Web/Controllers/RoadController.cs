using Microsoft.AspNetCore.Mvc;

namespace RoadBoM.Web.Controllers
{
    public class RoadController : Controller
    {
        public IActionResult Register()
        {
            return View();
        }
    }
}
