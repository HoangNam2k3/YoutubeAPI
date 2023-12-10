using YoutubeAPI.Data;
using Microsoft.EntityFrameworkCore;
using YoutubeAPI.Models;

namespace YoutubeAPI.Services
{
    public class CategoryRepo : IRepoCategory
    {
        private readonly MyDbContext _dbContext;

        public CategoryRepo(MyDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<CategoryVM> CreateAsync(CategoryMD categoryMD)
        {
            var cat = new Category
            {
                category_name = categoryMD.category_name
            };
            _dbContext.Add(cat);
            await _dbContext.SaveChangesAsync();
            return new CategoryVM
            {
                category_id = cat.category_id,
                category_name = categoryMD.category_name
            };
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var cat = await _dbContext.Categories.SingleOrDefaultAsync(cate => cate.category_id == id);
            if (cat == null) return false;
            _dbContext.Remove(cat);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<List<CategoryVM>> GetAllAsync()
        {
            var categories = await _dbContext.Categories.Select(category => new CategoryVM
            {
                category_id = category.category_id,
                category_name = category.category_name
            }).ToListAsync();
            return categories;
        }

        public async Task<CategoryVM> GetByIdAsync(int id)
        {
            var category = await _dbContext.Categories.SingleOrDefaultAsync(cate => cate.category_id == id);
            if (category == null) return null!;
            return new CategoryVM
            {
                category_id = category.category_id,
                category_name = category.category_name
            };
        }

        public Task<bool> UpdateAsync(CategoryVM categoryVM)
        {
            throw new NotImplementedException();
        }
    }
}
