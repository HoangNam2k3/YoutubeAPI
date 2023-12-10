using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using YoutubeAPI.Models;
using YoutubeAPI.Services;

namespace YoutubeAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly IRepoCategory _repo;

        public CategoryController(IRepoCategory repo)
        {
            _repo = repo;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var cat = await _repo.GetAllAsync();
                return Ok(cat);
            }
            catch
            {
                return BadRequest();
            }
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var cat = await _repo.GetByIdAsync(id);
                if (cat == null) return NotFound();
                return Ok(cat);
            }
            catch
            {
                return BadRequest();
            }
        }
        [HttpPost]
        public async Task<IActionResult> Create(CategoryMD categoryMD)
        {
            try
            {
                var cat = await _repo.CreateAsync(categoryMD);
                return Ok(cat);
            }
            catch
            {
                return BadRequest();
            }
        }
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var cat = await _repo.DeleteAsync(id);
                if (cat == false) return NotFound();
                return Ok("Delete Success!");
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
