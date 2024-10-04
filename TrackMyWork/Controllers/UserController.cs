using Microsoft.AspNetCore.Mvc;

namespace TrackMyWork.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
