using HouseRentingSystem.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace HouseRentingSystem.Web.Data
{
    public class HouseRentingSystemDbContext : IdentityDbContext<ApplicationUser, IdentityRole<Guid>, Guid>
    {
        public HouseRentingSystemDbContext(DbContextOptions<HouseRentingSystemDbContext> options)
            : base(options)
        {
        }

        public DbSet<Category> Categories { get; set; } = null!;

        public DbSet<House> Houses { get; set; } = null!;

        public DbSet<Agent> Agents { get; set; } = null!;


        private Category CottageCategory { get; set; } = null!;
        private Category SingleCategory { get; set; } = null!;
        private Category DuplexCategory { get; set; } = null!;

        private House FirstHouse { get; set; } = null!;
        private House SecondHouse { get; set; } = null!;
        private House ThirdHouse { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(Assembly.GetAssembly(typeof(HouseRentingSystemDbContext)) ??
                Assembly.GetExecutingAssembly());

            CottageCategory = new Category()
            {
                Id = Guid.Parse("059702e9-619c-4b4d-9bf9-a0e7cc0d3415"),
                Name = "Cottage"
            };
            SingleCategory = new Category()
            {
                Id = Guid.Parse("ba19029f-d120-4f0b-a359-934c049f2e78"),
                Name = "Single-Family"
            };
            DuplexCategory = new Category()
            {
                Id = Guid.Parse("66c6a0c8-aeb4-45bb-beee-20a9d5b0aa48"),
                Name = "Duplex"
            };
            builder.Entity<Category>().HasData(CottageCategory, DuplexCategory, SingleCategory);

            SeedHouses();
            builder.Entity<House>().HasData(FirstHouse, SecondHouse, ThirdHouse);

            base.OnModelCreating(builder);
        }
        private void SeedHouses()
        {
            FirstHouse  = new House()
            {
                Title = "Big House Marina",
                Address = "North London, UK (near the border)",
                Description = "A big house for your whole family. Don't miss to buy a house with three bedrooms.",
                ImageUrl = "https://www.luxury-architecture.net/wpcontent/uploads/2017/12/1513217889-7597-FAIRWAYS-010.jpg",
                PricePerMonth = 2100.00M,
                CategoryId = Guid.Parse("66c6a0c8-aeb4-45bb-beee-20a9d5b0aa48"),
                AgentId = Guid.Parse("FBEA963A-1B24-401E-9F72-9CEF9E1CFA0F"),
                RenterId = Guid.Parse("9AAF3908-B775-4702-160B-08DB76E40DF7")
            };
            SecondHouse = new House()
            {
                Title = "Family House Comfort",
                Address = "Near the Sea Garden in Burgas, Bulgaria",
                Description = "It has the best comfort you will ever ask for. With twobedrooms,it is great for your family.",
                ImageUrl = "https://cf.bstatic.com/xdata/images/hotel/max1024x768/179489660.jpg?k=2029f6d9589b49c95dcc9503a265e292c2cdfcb5277487a0050397c3f8dd545a & o = &hp = 1",
                PricePerMonth = 1200.00M,
                CategoryId = Guid.Parse("ba19029f-d120-4f0b-a359-934c049f2e78"),
                AgentId = Guid.Parse("FBEA963A-1B24-401E-9F72-9CEF9E1CFA0F"),
            };
            ThirdHouse = new House()
            {
                Title = "Grand House",
                Address = "Boyana Neighbourhood, Sofia, Bulgaria",
                Description = "This luxurious house is everything you will need. It isjust excellent.",
                ImageUrl = "https://i.pinimg.com/originals/a6/f5/85/a6f5850a77633c56e4e4ac4f867e3c00.jpg",
                PricePerMonth = 2000.00M,
                CategoryId = Guid.Parse("66c6a0c8-aeb4-45bb-beee-20a9d5b0aa48"),
                AgentId = Guid.Parse("FBEA963A-1B24-401E-9F72-9CEF9E1CFA0F"),
            };
        }
    }
}