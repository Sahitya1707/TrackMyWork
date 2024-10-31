using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Linq;
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
            Console.WriteLine(projects);

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
        public async Task<IActionResult> Create([Bind("Title, Description, ClientId, StartDate, Urgency, DeadlineDate, Status")]Project project)
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
        public async Task<IActionResult> Edit(int id)
        {
            var project = await _context.Projects.FindAsync(id);
            if (project== null)
            {
                return NotFound();
            }
            ViewBag.Clients = await _context.Clients.ToListAsync();
            return View(project);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Title, Description, ClientId, StartDate, DeadlineDate, Urgency, Status")] Project project)
        {
            // checking if we goes inside if function or not
            Console.WriteLine("this is outside");

            if (id != project.ProjectId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                Console.WriteLine("Going inside");

                _context.Update(project); // Update the client in the database
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index)); // Redirect to Index view


            }

            return View(project);
        }
// Delete function
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int? id)
        {
           
            if (id == null)
            {
                return NotFound();
            }

            var project = await _context.Projects.FindAsync(id);
            if (project == null)
            {
                return NotFound();
            }
            else
            {
                _context.Projects.Remove(project);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));

        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            { 
                return NotFound();
            }
            var project = await _context.Projects
         .Include(p => p.Messages)
         .FirstOrDefaultAsync(m => m.ProjectId == id);

            // using view model as I want to send message from detail view so it will be the case of using both project model and message model at once.
            // https://education.launchcode.org/csharp-web-dev-curriculum/viewmodels/reading/viewmodels-intro/index.html
            // https://stackoverflow.com/questions/11064316/what-is-viewmodel-in-mvc 
            // ------------------------
            var viewModel = new ProjectDetailViewModel
            {
                Project = project,
                Message = new Message() // Placeholder message for the form
            };
            return View(viewModel);
        }
        
        // adding submit message action
   
        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> SendMessage([Bind("MessageId,Content,ProjectId,SenderMail,IsRead, SentDate")]Message message)
        {
            Console.WriteLine(message.MessageId);
            Console.WriteLine(message.SenderMail);
            Console.WriteLine(message.SentDate);
            Console.WriteLine(message.ProjectId);
            Console.WriteLine(message.Content);
            Console.WriteLine("I am outside of model valid state");

            if (!ModelState.IsValid)
            {
              
                foreach (var modelState in ModelState.Values)
                {
                    foreach (var error in modelState.Errors)
                    {
                        Console.WriteLine(error.ErrorMessage);
                    }
                }
            }
                if (ModelState.IsValid)
                {
                    Console.WriteLine("I am inside of model valid state");
                    Console.WriteLine(message.MessageId);
                    Console.WriteLine(message.SenderMail);
                    Console.WriteLine(message.SentDate);
                    Console.WriteLine(message.Content);
                    Console.WriteLine(message.ProjectId);
                    Console.WriteLine("I am not outside");
                    message.SentDate = DateTime.Now;
                    message.SenderMail = User.Identity?.Name; // as the Sendermail is static so getting is directly through user.identity
                    _context.Add(message);
                    await _context.SaveChangesAsync();
                return RedirectToAction("Details", "Project", new { id = 6 });

            }
            // redirecting the form submission to same page , 
            // https://aboutdev.wordpress.com/2013/01/22/asp-net-mvc-3-redirect-query-string-with-id/
            return RedirectToAction("Details", "Project", new { id = message.ProjectId });
        }
          
        }

    }

