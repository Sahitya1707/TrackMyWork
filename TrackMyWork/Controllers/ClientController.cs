using Microsoft.AspNetCore.Mvc;

namespace TrackMyWork.Controllers
{
    public class ClientController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
