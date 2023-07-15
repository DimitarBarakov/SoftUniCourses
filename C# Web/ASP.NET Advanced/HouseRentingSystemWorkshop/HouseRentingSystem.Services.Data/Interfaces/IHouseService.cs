using HouseRentingSystem.Data.Models;
using HouseRentingSystem.Services.Models;
using HouseRentingSystem.Web.ViewModels.Home;
using HouseRentingSystem.Web.ViewModels.House;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HouseRentingSystem.Services.Data.Interfaces
{
    public interface IHouseService
    {
        Task<IEnumerable<IndexViewModel>> LastThreeHousesAsync();

        Task AddAsync(AddHouseViewModel model, string agentId);

        Task<AllHousesFilteredAndPagedServiceModel> AllAsync(AllHousesQueryModel model);

        Task<List<AllHouseViewModel>> AllHousesByAgentIdAsync(string agentId);
        Task<List<AllHouseViewModel>> AllHousesByUserIdAsync(string userId);

        Task<DetailsHouseViewModel> ShowHouseDetails(string houseId);

        Task<House> GetHouseById(string houseId);

        Task EditHouse(AddHouseViewModel model, string agentId, string houseId);

        Task<bool> IsAgentWithIdOwnerToHouseWithId(string agentId, string houseId);

        Task Delete(string id);

        Task<bool> IsRented(string houseId);

        Task RentHouse(string houseId, string userId);

        Task<bool> IsHouseRentedByUserWithId(string houseId, string userId);

        Task LeaveHouse(string houseId);
    }
}
