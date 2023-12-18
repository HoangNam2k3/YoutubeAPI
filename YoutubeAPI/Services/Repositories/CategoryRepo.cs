using AutoMapper;
using Microsoft.EntityFrameworkCore;
using YoutubeAPI.Context;
using YoutubeAPI.DTOs;
using YoutubeAPI.Helpers;
using YoutubeAPI.Models;
using YoutubeAPI.Services.Interfaces;
using static System.Net.Mime.MediaTypeNames;

namespace YoutubeAPI.Services.Repositories
{
    public class CategoryRepo : IRepoCategory
    {
        private readonly MyDbContext _dbContext;
        private readonly IMapper _mapper;

        public CategoryRepo(MyDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public async Task<CategoryDto> CreateAsync(CategoryMD categoryMD)
        {
            var cat = new Category
            {
                category_name = categoryMD.category_name
            };
            _dbContext.Add(cat);
            await _dbContext.SaveChangesAsync();
            return _mapper.Map<CategoryDto>(cat);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var cat = await _dbContext.Categories.SingleOrDefaultAsync(cate => cate.category_id == id);
            if (cat == null) return false;
            _dbContext.Remove(cat);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<List<CategoryDto>> GetAllAsync()
        {
            var categories = await _dbContext.Categories.Select(category => _mapper.Map<CategoryDto>(category))
                .ToListAsync();
            return categories;
        }

        public async Task<CategoryDto> GetByIdAsync(int id)
        {
            var category = await _dbContext.Categories.SingleOrDefaultAsync(cate => cate.category_id == id);
            if (category == null) return null!;
            return _mapper.Map<CategoryDto>(category);
        }

        public Task<bool> UpdateAsync(CategoryDto categoryVM)
        {
            throw new NotImplementedException();
        }
    }
}
