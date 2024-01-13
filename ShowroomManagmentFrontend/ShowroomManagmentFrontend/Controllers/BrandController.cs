using Microsoft.AspNetCore.Mvc;

namespace ShowroomManagmentFrontend.Controllers
{
    public class BrandController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
