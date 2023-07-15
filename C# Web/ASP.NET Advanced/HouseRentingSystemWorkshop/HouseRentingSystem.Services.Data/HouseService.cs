using HouseRentingSystem.Data.Models;
using HouseRentingSystem.Services.Data.Interfaces;
using HouseRentingSystem.Services.Models;
using HouseRentingSystem.Web.Data;
using HouseRentingSystem.Web.ViewModels.Agent;
using HouseRentingSystem.Web.ViewModels.Home;
using HouseRentingSystem.Web.ViewModels.House;
using HouseRentingSystem.Web.ViewModels.House.Enums;
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

        public async Task<AllHousesFilteredAndPagedServiceModel> AllAsync(AllHousesQueryModel model)
        {
            IQueryable<House> housesQuery = dbContext.Houses.AsQueryable();

            if (!string.IsNullOrWhiteSpace(model.Category))
            {
                housesQuery = housesQuery.Where(h => h.Category.Name == model.Category);
            }
            if (!string.IsNullOrWhiteSpace(model.SearchString))
            {
                string wildCard = $"%{model.SearchString.ToLower()}%";
                housesQuery = housesQuery.Where(h =>
                        EF.Functions.Like(h.Address, wildCard) ||
                        EF.Functions.Like(h.Title, wildCard) ||
                        EF.Functions.Like(h.Description, wildCard) );
            }
            housesQuery = model.HouseSorting switch
            {
                HouseSorting.Newest => housesQuery.OrderBy(h => h.CreatedOn),
                HouseSorting.Oldest => housesQuery.OrderByDescending(h => h.CreatedOn),
                HouseSorting.PriceAscending => housesQuery.OrderBy(h => h.PricePerMonth),
                HouseSorting.PriceDescending => housesQuery.OrderByDescending(h => h.PricePerMonth),
                _ => housesQuery.OrderBy(h=>h.RenterId != null).ThenByDescending(h=>h.CreatedOn)
            } ;

            List<AllHouseViewModel> allHouses =await housesQuery
                .Skip((model.CurrentPage - 1) * model.HousesPerPage)
                .Take(model.HousesPerPage)
                .Select(h=>new AllHouseViewModel()
                {
                    Id = h.Id.ToString(),
                    Title = h.Title,
                    Address = h.Address,
                    ImageUrl = h.ImageUrl,
                    PricePerMonth = h.PricePerMonth,
                    IsRented = h.RenterId.HasValue
                })
                .ToListAsync();

            int totalHouses = model.TotalHouses;

            return new AllHousesFilteredAndPagedServiceModel()
            {
                TotalHousesCount = totalHouses,
                Houses = allHouses
            };
        }

        public async Task<List<AllHouseViewModel>> AllHousesByAgentIdAsync(string agentId)
        {
            List<AllHouseViewModel> housesByAgent = await dbContext.Houses
                .Where(h => h.AgentId.ToString() == agentId)
                .Select(h=> new AllHouseViewModel()
                {
                    Id = h.Id.ToString(),
                    Title = h.Title,
                    Address = h.Address,
                    ImageUrl = h.ImageUrl,
                    PricePerMonth = h.PricePerMonth,
                    IsRented = h.RenterId.HasValue
                })
                .ToListAsync();

            return housesByAgent;
        }

        public async Task<List<AllHouseViewModel>> AllHousesByUserIdAsync(string userId)
        {
            List<AllHouseViewModel> housesByUser = await dbContext.Houses
                .Where(h => h.RenterId.ToString() == userId && h.RenterId.HasValue)
                .Select(h => new AllHouseViewModel()
                {
                    Id = h.Id.ToString(),
                    Title = h.Title,
                    Address = h.Address,
                    ImageUrl = h.ImageUrl,
                    PricePerMonth = h.PricePerMonth,
                    IsRented = h.RenterId.HasValue
                })
                .ToListAsync();

            return housesByUser;
        }

        public async Task Delete(string id)
        {
            House house = await GetHouseById(id);

            dbContext.Houses.Remove(house);
            await dbContext.SaveChangesAsync();
        }

        public async Task EditHouse(AddHouseViewModel model, string agentId, string houseId)
        {
            var houseToEdit = await dbContext.Houses.FirstAsync(h => h.Id.ToString() == houseId);

            houseToEdit.Title = model.Title;
            houseToEdit.Description = model.Description;
            houseToEdit.Address = model.Address;
            houseToEdit.PricePerMonth = model.PricePerMonth;
            houseToEdit.ImageUrl = model.ImageUrl;
            houseToEdit.CategoryId = model.CategoryId;
            houseToEdit.AgentId = Guid.Parse(agentId);

            await dbContext.SaveChangesAsync();
        }

        public async Task<House> GetHouseById(string houseId)
        {
            var house = await dbContext.Houses.FirstAsync(h => h.Id.ToString() == houseId);

            return house;
        }

        public async Task<bool> IsAgentWithIdOwnerToHouseWithId(string agentId, string houseId)
        {
            var house = await GetHouseById(houseId);

            return house.AgentId == Guid.Parse(agentId);
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

        public async Task<DetailsHouseViewModel> ShowHouseDetails(string houseId)
        {
            var house = await dbContext.Houses
                .Include(h=>h.Category)
                .Include(h=>h.Agent)
                .ThenInclude(a=>a.User)
                .FirstAsync(h=>h.Id.ToString() == houseId);

            AgentInfoInDetailsHouseViewModel agent = new AgentInfoInDetailsHouseViewModel()
            {
               PhoneNumber = house.Agent.PhoneNumber,
               Email = house.Agent.User.Email
            };

            DetailsHouseViewModel model = new DetailsHouseViewModel()
            {
                Id = house.Id.ToString(),
                Title = house.Title,
                Address = house.Address,
                Description = house.Description,
                Category = house.Category.Name,
                ImageUrl = house.ImageUrl,
                PricePerMonth = house.PricePerMonth,
                IsRented = house.RenterId.HasValue,
                Agent = agent
            };
            return model;
        }

        public async Task<bool> IsRented(string houseId)
        {
            House house = await GetHouseById(houseId);

            bool res = house.RenterId.HasValue;

            return res;
        }

        public async Task RentHouse(string houseId, string userId)
        {
            var house = await GetHouseById(houseId);
            house.RenterId = Guid.Parse(userId);
            await dbContext.SaveChangesAsync();
        }

        public async Task<bool> IsHouseRentedByUserWithId(string houseId, string userId)
        {
            var house = await GetHouseById(houseId);

            bool res = house.RenterId.ToString() == userId;

            return res;
        }

        public async Task LeaveHouse(string houseId)
        {
            var house = await GetHouseById(houseId);

            house.RenterId = null;
            await dbContext.SaveChangesAsync();
        }
    }
}
