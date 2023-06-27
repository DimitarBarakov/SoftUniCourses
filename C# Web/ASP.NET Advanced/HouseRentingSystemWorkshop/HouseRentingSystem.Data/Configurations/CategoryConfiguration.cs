using HouseRentingSystem.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HouseRentingSystem.Data.Configurations
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        //private Category CottageCategory { get; set; } = null!;
        //private Category SingleCategory { get; set; } = null!;
        //private Category DuplexCategory { get; set; } = null!;


        public void Configure(EntityTypeBuilder<Category> builder)
        {
            //CottageCategory = new Category()
            //{
            //    Id = Guid.Parse("059702e9 - 619c - 4b4d - 9bf9 - a0e7cc0d3415"),
            //    Name = "Cottage"
            //};
            //SingleCategory = new Category()
            //{
            //    Id = Guid.Parse("ba19029f-d120-4f0b-a359-934c049f2e78"),
            //    Name = "Single-Family"
            //};
            //DuplexCategory = new Category()
            //{
            //    Id = Guid.Parse("66c6a0c8-aeb4-45bb-beee-20a9d5b0aa48"),
            //    Name = "Duplex"
            //};
            //builder.HasData(CottageCategory,DuplexCategory,SingleCategory);
        }
        //private void SeedCategories()
        //{
            
        //}

        //private Category[] GenerateCategories()
        //{
        //    List<Category> categories = new List<Category>();
        //    Category category;
        //    category = new Category
        //    {
        //        Id = Guid.Parse("059702e9 - 619c - 4b4d - 9bf9 - a0e7cc0d3415"),
        //        Name = "Cottage"
        //    };
        //    categories.Add(category);

        //    category = new Category
        //    {
        //        Id = Guid.Parse("ba19029f-d120-4f0b-a359-934c049f2e78"),
        //        Name = "Single-Family"
        //    };
        //    categories.Add(category);

        //    category = new Category
        //    {
        //        Id = Guid.Parse("66c6a0c8-aeb4-45bb-beee-20a9d5b0aa48"),
        //        Name = "Duplex"
        //    };
        //    categories.Add(category);

        //    return categories.ToArray();
        //}
    }
}
