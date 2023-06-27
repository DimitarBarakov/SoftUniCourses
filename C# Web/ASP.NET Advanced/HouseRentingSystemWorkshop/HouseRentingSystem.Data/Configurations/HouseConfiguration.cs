using HouseRentingSystem.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HouseRentingSystem.Data.Configurations
{
    public class HouseConfiguration : IEntityTypeConfiguration<House>
    {
        public void Configure(EntityTypeBuilder<House> builder)
        {
            builder
                .HasOne(h => h.Category)
                .WithMany(c => c.Houses)
                .HasForeignKey(h => h.CategoryId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne(h => h.Agent)
                .WithMany(a => a.OwnedHouses)
                .HasForeignKey(h => h.AgentId)
                .OnDelete(DeleteBehavior.Restrict);

            //builder.HasData(this.GenerateHouses());

        }

        //private House[] GenerateHouses()
        //{
        //    List<House> houses = new List<House>();

        //    House house;

        //    house = new House
        //    {
        //        Title = "Big House Marina",
        //        Address = "North London, UK (near the border)",
        //        Description = "A big house for your whole family. Don't miss to buy a house with three bedrooms.",
        //        ImageUrl = "https://www.luxury-architecture.net/wpcontent/uploads/2017/12/1513217889-7597-FAIRWAYS-010.jpg",
        //        PricePerMonth = 2100.00M,
        //        CategoryId = Guid.Parse("66c6a0c8-aeb4-45bb-beee-20a9d5b0aa48"),
        //        AgentId = Guid.Parse("FBEA963A-1B24-401E-9F72-9CEF9E1CFA0F"),
        //        RenterId = Guid.Parse("9AAF3908-B775-4702-160B-08DB76E40DF7")
        //    };
        //    houses.Add(house);

        //    house = new House
        //    {
        //        Title = "Family House Comfort",
        //        Address = "Near the Sea Garden in Burgas, Bulgaria",
        //        Description = "It has the best comfort you will ever ask for. With twobedrooms,it is great for your family.",
        //        ImageUrl ="https://cf.bstatic.com/xdata/images/hotel/max1024x768/179489660.jpg?k=2029f6d9589b49c95dcc9503a265e292c2cdfcb5277487a0050397c3f8dd545a & o = &hp = 1",
        //        PricePerMonth = 1200.00M,
        //        CategoryId = Guid.Parse("ba19029f-d120-4f0b-a359-934c049f2e78"),
        //        AgentId = Guid.Parse("FBEA963A-1B24-401E-9F72-9CEF9E1CFA0F"),
        //    };
        //    houses.Add(house);

        //    house = new House
        //    {
        //        Title = "Grand House",
        //        Address = "Boyana Neighbourhood, Sofia, Bulgaria",
        //        Description = "This luxurious house is everything you will need. It isjust excellent.",
        //        ImageUrl ="https://i.pinimg.com/originals/a6/f5/85/a6f5850a77633c56e4e4ac4f867e3c00.jpg",
        //        PricePerMonth = 2000.00M,
        //        CategoryId = Guid.Parse("66c6a0c8-aeb4-45bb-beee-20a9d5b0aa48"),
        //        AgentId = Guid.Parse("FBEA963A-1B24-401E-9F72-9CEF9E1CFA0F"),
        //    };
        //    houses.Add(house);

        //    return houses.ToArray();
        //}
    }
}
