using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HouseRentingSystem.Data.Migrations
{
    public partial class SeedHouses : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Houses",
                columns: new[] { "Id", "Address", "AgentId", "CategoryId", "Description", "ImageUrl", "PricePerMonth", "RenterId", "Title" },
                values: new object[] { new Guid("55a061e6-8831-4f02-9c4b-cfe6d0677ebc"), "Boyana Neighbourhood, Sofia, Bulgaria", new Guid("fbea963a-1b24-401e-9f72-9cef9e1cfa0f"), new Guid("66c6a0c8-aeb4-45bb-beee-20a9d5b0aa48"), "This luxurious house is everything you will need. It isjust excellent.", "https://i.pinimg.com/originals/a6/f5/85/a6f5850a77633c56e4e4ac4f867e3c00.jpg", 2000.00m, null, "Grand House" });

            migrationBuilder.InsertData(
                table: "Houses",
                columns: new[] { "Id", "Address", "AgentId", "CategoryId", "Description", "ImageUrl", "PricePerMonth", "RenterId", "Title" },
                values: new object[] { new Guid("ca5d1685-bbda-45bf-9cc5-61680ee79308"), "North London, UK (near the border)", new Guid("fbea963a-1b24-401e-9f72-9cef9e1cfa0f"), new Guid("66c6a0c8-aeb4-45bb-beee-20a9d5b0aa48"), "A big house for your whole family. Don't miss to buy a house with three bedrooms.", "https://www.luxury-architecture.net/wpcontent/uploads/2017/12/1513217889-7597-FAIRWAYS-010.jpg", 2100.00m, new Guid("9aaf3908-b775-4702-160b-08db76e40df7"), "Big House Marina" });

            migrationBuilder.InsertData(
                table: "Houses",
                columns: new[] { "Id", "Address", "AgentId", "CategoryId", "Description", "ImageUrl", "PricePerMonth", "RenterId", "Title" },
                values: new object[] { new Guid("f10b0bc3-ee7b-45ee-91cc-3dcca4af2a2d"), "Near the Sea Garden in Burgas, Bulgaria", new Guid("fbea963a-1b24-401e-9f72-9cef9e1cfa0f"), new Guid("ba19029f-d120-4f0b-a359-934c049f2e78"), "It has the best comfort you will ever ask for. With twobedrooms,it is great for your family.", "https://cf.bstatic.com/xdata/images/hotel/max1024x768/179489660.jpg?k=2029f6d9589b49c95dcc9503a265e292c2cdfcb5277487a0050397c3f8dd545a & o = &hp = 1", 1200.00m, null, "Family House Comfort" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Houses",
                keyColumn: "Id",
                keyValue: new Guid("55a061e6-8831-4f02-9c4b-cfe6d0677ebc"));

            migrationBuilder.DeleteData(
                table: "Houses",
                keyColumn: "Id",
                keyValue: new Guid("ca5d1685-bbda-45bf-9cc5-61680ee79308"));

            migrationBuilder.DeleteData(
                table: "Houses",
                keyColumn: "Id",
                keyValue: new Guid("f10b0bc3-ee7b-45ee-91cc-3dcca4af2a2d"));
        }
    }
}
