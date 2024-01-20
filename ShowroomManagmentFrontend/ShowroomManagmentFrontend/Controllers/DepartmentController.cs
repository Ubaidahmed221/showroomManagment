using Microsoft.AspNetCore.Mvc;

namespace ShowroomManagmentFrontend.Controllers
{
    public class DepartmentController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Create()
        {
            return View();
        }
    }
}
