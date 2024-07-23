using Microsoft.AspNetCore.Mvc;

namespace RoadBoM.Web.Controllers
{
    public class SettingController : Controller
    {
        public IActionResult BillCategories()
        {
            return View();
        }
    }
}
