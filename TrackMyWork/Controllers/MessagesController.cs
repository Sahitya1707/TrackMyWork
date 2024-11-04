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
        public async Task<IActionResult> Create()
        {
            // this whill reaturn the current client  ( my approach for filter the send message. I mean client should be only able to send message their own project not on other's project)

            var currentClient = await _context.Clients
        .FirstOrDefaultAsync(c => c.Email == User.Identity.Name);

         
            // targeting all the project
            var projectsForClient = await _context.Projects.ToListAsync();
            if (User.IsInRole("Client"))
            {
                // if user role is client, let's filter the project
                 projectsForClient = await _context.Projects
               .Where(p => p.ClientId == currentClient.ClientId) 
               .ToListAsync();
            }
               

            // targeting project id
            ViewData["ProjectId"] = new SelectList(projectsForClient, "ProjectId", "Title");
            ViewData["SenderEmail"] = User.Identity?.Name; // Capture the sender's email

            return View();
        }

        // POST: Messages/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MessageId,Content,ProjectId,SenderMail,IsRead, SentDate")] Message message)
        {
            // Retrieve the current client to get the ClientId
            var currentClient = await _context.Clients
                .FirstOrDefaultAsync(c => c.Email == User.Identity.Name);

           

            if (ModelState.IsValid)
            {
                message.SentDate = DateTime.Now; 
                message.SenderMail = User.Identity?.Name; 
              

                _context.Add(message);
                await _context.SaveChangesAsync(); 
                return RedirectToAction(nameof(Index)); // Redirect to the index action
            }

           
            ViewData["ProjectId"] = new SelectList(_context.Projects.Where(p => p.ClientId == currentClient.ClientId), "ProjectId", "Title", message.ProjectId);

            return View(message); 

        }

        private bool MessageExists(int id)
        {
            return _context.Messages.Any(e => e.MessageId == id);
        }
    }
}
