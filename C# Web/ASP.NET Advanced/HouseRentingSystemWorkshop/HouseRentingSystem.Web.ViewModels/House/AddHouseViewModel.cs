using static HouseRentingSystem.Common.EntityValidationsConstants.House;
using System.ComponentModel.DataAnnotations;
using HouseRentingSystem.Web.ViewModels.Category;

namespace HouseRentingSystem.Web.ViewModels.House
{
    public class AddHouseViewModel
    {
        [Required]
        [StringLength(TitleMaxLength, MinimumLength = TitleMinLength)]
        public string Title { get; set; } = null!;

        [Required]
        [StringLength(AddressMaxLength, MinimumLength = AddressMinLength)]
        public string Address { get; set; } = null!;

        [Required]
        [StringLength(DescriptionMaxLength, MinimumLength = DescriptionMinLength)]
        public string Description { get; set; } = null!;

        [Required]
        [StringLength(ImageUrlMaxLength)]
        public string ImageUrl { get; set; } = null!;

        [Required]
        [Range(PriceMin, PriceMax)]
        public decimal PricePerMonth { get; set; }
        public Guid CategoryId { get; set; }
        public List<CategoryViewModel> Categories { get; set; } = new List<CategoryViewModel>();
    }
}
