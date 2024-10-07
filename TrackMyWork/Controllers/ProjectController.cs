using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

using TrackMyWork.Data;
using TrackMyWork.Models;
namespace TrackMyWork.Controllers
{
    public class ProjectController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ProjectController(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            // need to add clients or get the clients from the db in order to loop/use it in index.cshtml view

            var projects = await _context.Projects.Include(p => p.Client).ToListAsync();


            return View(projects);
        }
        public async Task<IActionResult> Create() {
            /** view bag is just a general way to send data from controller to view, I need the client data so I did this https://stackify.com/viewbag/#:~:text=In%20general%2C%20ViewBag%20is%20a,was%20introduced%20in%20MVC%201.0).
             */
         
            ViewBag.Clients =await _context.Clients.ToListAsync();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Project project)
        {
           
            if (ModelState.IsValid)
            {
                Console.WriteLine("Form submitted.");

                // Save the project to the database
                _context.Projects.Add(project);
                await _context.SaveChangesAsync(); 

                return RedirectToAction("Index");
            }
           
          
            return View(project);
        }
    }
}
