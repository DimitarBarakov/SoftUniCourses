using HouseRentingSystem.Web.ViewModels.House;

namespace HouseRentingSystem.Services.Models
{
    public class AllHousesFilteredAndPagedServiceModel
    {
        public int TotalHousesCount { get; set; }

        public List<AllHouseViewModel> Houses{ get; set; } = new List<AllHouseViewModel>();
    }
}
