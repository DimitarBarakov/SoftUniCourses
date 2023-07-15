using HouseRentingSystem.Data.Models;
using HouseRentingSystem.Services.Data.Interfaces;
using HouseRentingSystem.Services.Models;
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
            this.categoryService = service;
            this.agentService = agentService;
            this.houseService = houseService;
        }
        
        [AllowAnonymous]
        public async Task<IActionResult> All([FromQuery]AllHousesQueryModel queryModel)
        {
            AllHousesFilteredAndPagedServiceModel model = await houseService.AllAsync(queryModel);

            queryModel.Houses = model.Houses;
            queryModel.TotalHouses = model.TotalHousesCount;
            queryModel.Categories = await categoryService.AllCategoryNamesASync();

            return View(queryModel);
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
                ModelState.AddModelError(nameof(model.CategoryId), "Selected category does not exists");
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

        public async Task<IActionResult> Mine()
        {
            List<AllHouseViewModel> houses;

            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (await agentService.AgentExistsByUserId(userId))
            {
                string? agentId = await agentService.GetAgentIdByUserId(userId);

                houses = await houseService.AllHousesByAgentIdAsync(agentId!);
            }
            else
            {
                houses = await houseService.AllHousesByUserIdAsync(userId);
            }

            return View(houses);
        }

        [AllowAnonymous]
        public async Task<IActionResult> Details(string id)
        {
            var model = await houseService.ShowHouseDetails(id);

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(string id)
        {
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (!await agentService.AgentExistsByUserId(userId))
            {
                return RedirectToAction("Become", "Agent");
            }
            House house = await houseService.GetHouseById(id);

            var model = new AddHouseViewModel()
            {
                Title = house.Title,
                Address = house.Address,
                Description = house.Description,
                ImageUrl = house.ImageUrl,
                PricePerMonth = house.PricePerMonth,
                CategoryId = house.CategoryId,
                Categories = await categoryService.AllCategoriesAsync()
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(AddHouseViewModel model, string id)
        {
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (!ModelState.IsValid)
            {
                model.Categories = await categoryService.AllCategoriesAsync();

                return View(model);
            }

            string? agentId = await agentService.GetAgentIdByUserId(userId);

            bool isAgentOwner = await houseService.IsAgentWithIdOwnerToHouseWithId(agentId!, id);
            if (!isAgentOwner)
            {
                return RedirectToAction("Mine");
            }

            await houseService.EditHouse(model, agentId!, id);
            return RedirectToAction("Details", new {id});
        }

        [HttpGet]
        public async Task<IActionResult> Delete(string id)
        {
            House house = await houseService.GetHouseById(id);

            var model = new DeleteHouseViewModel()
            {
                Id = house.Id.ToString(),
                Title = house.Title,
                Address = house.Address,
                ImageUrl = house.ImageUrl
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(DeleteHouseViewModel model)
        {
            await houseService.Delete(model.Id);

            return RedirectToAction("Mine");
        }

        [HttpPost]
        public async Task<IActionResult> Rent(string id)
        {
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var house = await houseService.GetHouseById(id);

            if (house == null)
            {
                return RedirectToAction("All");
            }
            if (await houseService.IsRented(id))
            {
                return BadRequest();
            }
            if (await agentService.AgentExistsByUserId(userId))
            {
                return BadRequest();
            }
            try
            {
                await houseService.RentHouse(id, userId);
            }
            catch(Exception)
            {
                return RedirectToAction("all");
            }
            return RedirectToAction("Mine");
        }
        [HttpPost]
        public async Task<IActionResult> Leave(string id)
        {
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var house = await houseService.GetHouseById(id);

            if (house == null)
            {
                return BadRequest("House does not exist");
            }
            if (!await houseService.IsRented(id))
            {
                return BadRequest("House is not rented");
            }
            if (await agentService.AgentExistsByUserId(userId))
            {
                return BadRequest("You should be renter");
            }

            if (!await this.houseService.IsHouseRentedByUserWithId(id, userId))
            {
                return BadRequest("You should be the renter of hte house");
            }

            await houseService.LeaveHouse(id);
            return RedirectToAction("Mine");
        }
    }
}
