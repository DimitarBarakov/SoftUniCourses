using System.ComponentModel.DataAnnotations;
using static HouseRentingSystem.Common.EntityValidationsConstants.Category;

namespace HouseRentingSystem.Data.Models
{
    public class Category
    {
        public Category()
        {
            this.Id = Guid.NewGuid();
        }
        [Key]
        public Guid Id { get; set; }

        [Required]
        [MaxLength(CategoryNameMaxLength)]
        public string Name { get; set; } = null!;

        public List<House> Houses { get; set; } = new List<House>();
    }
}