using HouseRentingSystem.Services.Data.Interfaces;
using HouseRentingSystem.Web.Data;
using HouseRentingSystem.Web.ViewModels.Home;
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
