using HouseRentingSystem.Data.Models;
using HouseRentingSystem.Services.Data.Interfaces;
using HouseRentingSystem.Web.Data;
using HouseRentingSystem.Web.ViewModels.Home;
using HouseRentingSystem.Web.ViewModels.House;
using Microsoft.EntityFrameworkCore;

namespace HouseRentingSystem.Services.Data
{
    public class HouseService : IHouseService
    {
        private readonly HouseRentingSystemDbContext dbContext;

        public HouseService(HouseRentingSystemDbContext context)
        {
            dbContext = context;
        }

        public async Task AddAsync(AddHouseViewModel model, string agentId)
        {
            House houseToAdd = new House()
            {
                Title = model.Title,
                Address = model.Address,
                Description = model.Description,
                ImageUrl = model.ImageUrl,
                PricePerMonth = model.PricePerMonth,
                CategoryId = model.CategoryId,
                AgentId = Guid.Parse(agentId)
            };
            await dbContext.Houses.AddAsync(houseToAdd);
            await dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<IndexViewModel>> LastThreeHousesAsync()
        {
            List<IndexViewModel> lastThreeHouses = await dbContext.Houses
                .OrderByDescending(h => h.CreatedOn)
                .Take(3)
                .Select(h=> new IndexViewModel()
                {
                    Id = h.Id.ToString(),
                    Title = h.Title,
                    Description = h.Description,
                    ImageUrl = h.ImageUrl
                })
                .ToListAsync();

            return lastThreeHouses;
        }
    }
}
