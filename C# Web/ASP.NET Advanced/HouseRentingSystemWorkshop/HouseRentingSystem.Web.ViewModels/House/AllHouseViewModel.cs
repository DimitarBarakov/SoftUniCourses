namespace HouseRentingSystem.Web.ViewModels.House
{
    public class AllHouseViewModel
    {
        public string Id { get; set; } = null!;

        public string Title { get; set; } = null!;

        public string Address { get; set; } = null!;

        public string ImageUrl { get; set; } = null!;

        public decimal PricePerMonth { get; set; }

        public bool IsRented { get; set; }
    }
}
