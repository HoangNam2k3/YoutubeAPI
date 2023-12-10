using YoutubeAPI.Models;

namespace YoutubeAPI.Services
{
    public interface IRepoCategory
    {
        Task<List<CategoryVM>> GetAllAsync();
        Task<CategoryVM> GetByIdAsync(int id);
        Task<CategoryVM> CreateAsync(CategoryMD categoryMD);
        Task<bool> UpdateAsync(CategoryVM categoryVM);
        Task<bool> DeleteAsync(int id);
    }
}
