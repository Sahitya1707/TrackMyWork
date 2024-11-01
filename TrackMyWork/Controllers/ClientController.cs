using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

using TrackMyWork.Data;
using TrackMyWork.Models;

namespace TrackMyWork.Controllers
{
    [Authorize]
    [Authorize(Roles = "Freelancer")]
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
            // just checking if this is going inside or not.
             Console.WriteLine("this is outdie the mode valid");
           

            // Console.WriteLine(ModelState);
            if (ModelState.IsValid)
            {
                Console.WriteLine("Going inside the is valid");
                Console.WriteLine($"FirstName: {client.FirstName}, LastName: {client.LastName}, Email: {client.Email}");

                _context.Add(client); // Add the new client to the database
                try
                {
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index)); // Redirect to Index view
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error saving data: " + ex.Message);
                }

            }

            return View(client);
        }
        // handling edit 
        // GET: Client/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var client = await _context.Clients.FindAsync(id);
            if (client == null)
            {
                return NotFound();
            }
            return View(client);
        }

        // POST: Client/Edit/
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ClientId, FirstName, LastName, Email")] Client client)
        {
            // checking if we goes inside if function or not
            Console.WriteLine("We are outside");

            if (id != client.ClientId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                Console.WriteLine("Going inside");

                _context.Update(client); // Update the client in the database
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index)); // Redirect to Index view


            }

            return View(client);
        }

        // let's go with delete option now, I am trying to delete it instantly when you click the button
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int? id)
        {
            Console.WriteLine("We are inside here.");
            if (id == null)
            {
                return NotFound();
            }

            var client = await _context.Clients.FindAsync(id);
            if (client == null)
            {
                return NotFound();
            }
            else
            {
                _context.Clients.Remove(client);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));

        }
    }
}
