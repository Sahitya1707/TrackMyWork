using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TrackMyWork.Data;
using TrackMyWork.Models;

namespace TrackMyWork.Controllers
{
    public class ClientController : Controller


    {
        private readonly ApplicationDbContext _context;

        public ClientController(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
// need to add clients or get the clients from the db in order to loop/use it in index.cshtml view
            var clients = await _context.Clients.ToListAsync();
            return View(clients);
        }
        public IActionResult Create()
        {
            return View();
        }

// POST: Client/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ClientId, FirstName, LastName, Email")] Client client)
        {
            if (ModelState.IsValid)
            {
                _context.Add(client); // Add the new client to the database
                await _context.SaveChangesAsync(); 
                return RedirectToAction(nameof(Index)); // Redirect to Index view
            }
            return View(client);
        }
 // handling edit 
        //public async Task<IActionResult> Edit (int? id)
        //{
        //    if (id == null) {
        //        return NotFound();
        //    }

        //    //var client = await _context.Clients.FindAsync(id);

        //}
    }
}
