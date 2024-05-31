using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Areas.Teacher.Controllers
{
    [Area("Teacher")]
    [Authorize(Roles = "Teacher")]

    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}