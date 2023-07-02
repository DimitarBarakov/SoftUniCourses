using HouseRentingSystem.Services.Data.Interfaces;
using HouseRentingSystem.Web.ViewModels.House;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace HouseRentingSystem.Web.Controllers
{
    [Authorize]
    public class HouseController : Controller
    {
        private readonly ICategoryService categoryService;
        private readonly IAgentService agentService;
        private readonly IHouseService houseService;
        public HouseController(ICategoryService service, IAgentService agentService, IHouseService houseService)
        {
            categoryService = service;
            this.agentService = agentService;
            this.houseService = houseService;
        }

        [AllowAnonymous]
        public async Task<IActionResult> All()
        {
            return this.Ok();
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            bool isAgent = await this.agentService.AgentExistsByUserId(userId);
            if (!isAgent)
            {
                return RedirectToAction("Become", "Agent");
            }

            AddHouseViewModel model = new AddHouseViewModel()
            {
                Categories = await categoryService.AllCategoriesAsync()
            };

            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Add(AddHouseViewModel model)
        {
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            bool isAgent = await this.agentService.AgentExistsByUserId(userId);
            if (!isAgent)
            {
                return RedirectToAction("Become", "Agent");
            }

            bool doesCategoryExists = await categoryService.ExistById(model.CategoryId);
            if (!doesCategoryExists) 
            {
                ModelState.AddModelError(nameof(model.CategoryId), "Select category does not exists");
            }
            if (!ModelState.IsValid)
            {
                model.Categories = await categoryService.AllCategoriesAsync();

                return View(model);
            }
            try
            {
                string? agentId = await agentService.GetAgentIdByUserId(userId);
                await houseService.AddAsync(model, agentId!);
            }
            catch (Exception)
            {
                ModelState.AddModelError(string.Empty, "Unexpected error occurred");
                model.Categories = await categoryService.AllCategoriesAsync();

                return View(model);
            }

            return RedirectToAction("All");
        }
    }
}
