using HouseRentingSystem.Services.Data.Interfaces;
using HouseRentingSystem.Web.ViewModels.Agent;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace HouseRentingSystem.Web.Controllers
{
    [Authorize]
    public class AgentController : Controller
    {
        private readonly IAgentService agentService;

        public AgentController(IAgentService service)
        {
            agentService = service;
        }
        [HttpGet]
        public async Task<IActionResult> Become()
        {
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            bool isAgent = await agentService.AgentExistsByUserId(userId);
            if (isAgent) 
            {
                return this.BadRequest();
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Become(BecomeAgentFormModel model)
        {
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            bool isPhoneNumberTaken = await agentService.AgentExistsByPhoneNumberAsync(model.PhoneNumber);

            bool hasRents = await agentService.HasRentsAsync(userId);

            if (isPhoneNumberTaken)
            {
                ModelState.AddModelError(nameof(model.PhoneNumber), "The phone number is already taken");
            }

            if (!ModelState.IsValid)
            {
                return View(model);
            }
            if (hasRents)
            {
                return BadRequest();
            }

            await agentService.Create(userId, model);

            return RedirectToAction("Index", "Home");
        }
    }
}
