using HouseRentingSystem.Web.ViewModels.Category;

namespace HouseRentingSystem.Services.Data.Interfaces
{
    public interface ICategoryService
    {
        Task<List<CategoryViewModel>> AllCategoriesAsync();
        Task<bool> ExistById(Guid id);
    }
}
