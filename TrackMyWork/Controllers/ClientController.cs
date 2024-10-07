using Microsoft.AspNetCore.Mvc;
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
        public IActionResult Index()
        {
            return View();
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
                await _context.SaveChangesAsync(); // Save changes asynchronously
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
