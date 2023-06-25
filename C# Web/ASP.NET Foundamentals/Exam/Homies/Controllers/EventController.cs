using Homies.Data;
using Homies.Data.Models;
using Homies.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace Homies.Controllers
{
    [Authorize]
    public class EventController : Controller
    {
        private readonly HomiesDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;

        public EventController(HomiesDbContext context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }
        public async Task<IActionResult> All()
        {
            var models = await _context.Events
                .Select(e => new AllEventViewModel
                {
                    Id = e.Id,
                    Name = e.Name,
                    Organiser = e.Organiser.ToString(),
                    Start = e.Start.ToString("yyyy-MM-dd H:mm"),
                    Type = e.Type.Name
                })
                .ToListAsync();

            return View(models);
        }
        public async Task<IActionResult> Joined()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var models = await _context.EventsPerticipants.Where(ep => ep.HelperId == userId)
                .Select(ep => new JoinedEventViewModel
                {
                    Name = ep.Event.Name,
                    Id = ep.Event.Id,
                    Start = ep.Event.Start.ToString("yyyy-MM-dd H:mm"),
                    Type = ep.Event.Type.Name,
                    Organiser = ep.Event.Organiser.ToString()
                }).ToListAsync();

            return View(models);
        }
        [HttpGet]
        public async Task<IActionResult> Add()
        {
            var model = new AddEventViewModel();

            var types = await _context.Types
                .Select(t => new TypesViewModel
                {
                    Id = t.Id,
                    Name = t.Name
                }).ToListAsync();

            model.Types = types;

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddEventViewModel model)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var eventToAdd = new Event
            {
                Name = model.Name,
                Description = model.Description,
                CreatedOn = DateTime.Now,
                Start = model.Start,
                End = model.End,
                TypeId = model.TypeId,
                OrganiserId = userId
            };

            await _context.Events.AddAsync(eventToAdd);
            await _context.SaveChangesAsync();

            return RedirectToAction("All");
        }
        public async Task<IActionResult> Join(int id)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var model = await _context.Events.FindAsync(id);

            if (await _context.EventsPerticipants.AnyAsync(ep => ep.EventId == model.Id && ep.HelperId == userId))
            {
                return RedirectToAction("All");
            }

            var modelToAdd = new EventPerticipant
            {
                EventId = model.Id,
                HelperId = userId
            };

            await _context.AddAsync(modelToAdd);
            await _context.SaveChangesAsync();

            return RedirectToAction("Joined");
        }
        public async Task<IActionResult> Leave(int id)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var model = await _context.Events.FindAsync(id);

            var modelToRemove = await _context.EventsPerticipants.FirstAsync(ep => ep.EventId == model.Id && ep.HelperId == userId);

            _context.Remove(modelToRemove);
            await _context.SaveChangesAsync();

            return RedirectToAction("All");
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var eventt = await _context.Events.FindAsync(id);

            var model = new EditViewModel
            {
                Name = eventt.Name,
                Description = eventt.Description,
                Start = eventt.Start.ToString(),
                End = eventt.End.ToString(),
                TypeId = eventt.TypeId
            };
            var types = await _context.Types
                .Select(t => new TypesViewModel
                {
                    Id = t.Id,
                    Name = t.Name
                }).ToListAsync();

            model.Types = types;

            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(EditViewModel model, int id)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var eventToEdit = await _context.Events.FindAsync(id);
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            eventToEdit.Name = model.Name;
            eventToEdit.Description = model.Description;
            eventToEdit.CreatedOn = DateTime.Now;
            eventToEdit.Start =DateTime.Parse(model.Start);
            eventToEdit.End = DateTime.Parse(model.End);
            eventToEdit.TypeId = model.TypeId;
            eventToEdit.OrganiserId = userId;


            await _context.SaveChangesAsync();

            return RedirectToAction("All");
        }

        public async Task<IActionResult> Details(int id)
        {
            var eventt = await _context.Events.FindAsync(id);

            var model = new EventDetailsModel
            {
                Id = eventt.Id,
                Name = eventt.Name,
                Description = eventt.Description,
                Start = eventt.Start,
                End = eventt.End,
                OrganiserId = eventt.OrganiserId,
                CreatedOn = eventt.CreatedOn,
                TypeId = eventt.TypeId,
            };

            return View(model);
        }
    }
}
