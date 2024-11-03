using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TrackMyWork.Data;
using TrackMyWork.Models;
using Microsoft.AspNetCore.Identity;

using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;

namespace TrackMyWork.Controllers
{
    [Authorize]
    public class MessagesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MessagesController(ApplicationDbContext context)
        {
            _context = context;
        }

      
        public async Task<IActionResult> Index()
        {
            
            var currentUserEmail = User.Identity.Name;

           
            var allMessages = await _context.Messages
                .Include(m => m.Project) // Include related projects
                .OrderByDescending(m => m.SentDate) 
                .ToListAsync();

            // Filter messages based on user role
            IEnumerable<Message> filteredMessages;

            if (User.IsInRole("Client"))
            {
              // filtering so that client can see only their messge
                filteredMessages = allMessages.Where(m => m.SenderMail == currentUserEmail);
            }
            else
            {
               
                filteredMessages = allMessages;
            }

            return View(filteredMessages); 
        }
        // GET: Messages/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var message = await _context.Messages
                .Include(m => m.Project)
                //.Include(m => m.Sender)
                .FirstOrDefaultAsync(m => m.MessageId == id);
            if (message == null)
            {
                return NotFound();
            }

            return View(message);
        }

        // GET: Messages/Create
        public IActionResult Create()
        {
            ViewData["ProjectId"] = new SelectList(_context.Projects, "ProjectId", "Title");
            ViewData["SenderEmail"] = User.Identity?.Name;
        
            return View();
        }

        // POST: Messages/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MessageId,Content,ProjectId,SenderMail,IsRead, SentDate")] Message message)
        {
            Console.WriteLine("I am outise");
// see the error 
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
            Console.WriteLine(User.Identity?.Name);

            if (ModelState.IsValid)
            {
               Console.WriteLine("I am not outise");
                message.SentDate = DateTime.Now;
                message.SenderMail = User.Identity?.Name; // as the Sendermail is static so getting is directly through user.identity
                _context.Add(message);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ProjectId"] = new SelectList(_context.Projects, "ProjectId", "Title", message.ProjectId);
        
            return View(message);
        }

        private bool MessageExists(int id)
        {
            return _context.Messages.Any(e => e.MessageId == id);
        }
    }
}
