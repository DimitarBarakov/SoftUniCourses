using HouseRentingSystem.Web.ViewModels.House.Enums;
using static HouseRentingSystem.Common.GeneralConstants;

namespace HouseRentingSystem.Web.ViewModels.House
{
    public class AllHousesQueryModel
    {
        public AllHousesQueryModel()
        {
            this.HousesPerPage = DefaultHousesPerPage;
            this.CurrentPage = DefaultFirstPage;
        }
        public string? Category { get; set; }

        public string? SearchString { get; set; }

        public HouseSorting HouseSorting { get; set; }

        public int CurrentPage { get; set; }

        public int TotalHouses { get; set; }

        public int HousesPerPage { get; set; }

        public List<string> Categories { get; set; } = new List<string>();

        public List<AllHouseViewModel> Houses { get; set; } = new List<AllHouseViewModel>();
    }
}
