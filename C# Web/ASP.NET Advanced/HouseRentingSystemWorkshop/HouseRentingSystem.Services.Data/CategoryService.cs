using HouseRentingSystem.Services.Data.Interfaces;
using HouseRentingSystem.Web.Data;
using HouseRentingSystem.Web.ViewModels.Category;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HouseRentingSystem.Services.Data
{
    public class CategoryService : ICategoryService
    {
        private readonly HouseRentingSystemDbContext dbContext;

        public CategoryService(HouseRentingSystemDbContext context)
        {
            this.dbContext = context;
        }
        public async Task<List<CategoryViewModel>> AllCategoriesAsync()
        {
            List<CategoryViewModel> categories = await dbContext.Categories
                .Select(c => new CategoryViewModel()
                {
                    Id = c.Id,
                    Name = c.Name,
                })
                .ToListAsync();

            return categories;
        }

        public async Task<bool> ExistById(Guid id)
        {
            bool result = await dbContext.Categories
                .AnyAsync(c => c.Id == id);
            return result;
        }
    }
}
