using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using YoutubeAPI.Models;
using YoutubeAPI.Services;

namespace YoutubeAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VideoController : ControllerBase
    {
        private readonly IRepoVideo _repo;

        public VideoController(IRepoVideo repo)
        {
            _repo = repo;
        }
        [EnableCors("MyAllowSpecificOrigins")]
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var vids = await _repo.GetAllAsync();
                return Ok(vids);
            }
            catch
            {
                return BadRequest();
            }
        }
        [EnableCors("MyAllowSpecificOrigins")]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var vid = await _repo.GetByIdAsync(id);
                if (vid == null) return NotFound();
                return Ok(vid);
            }
            catch
            {
                return BadRequest();
            }
        }
        [EnableCors("MyAllowSpecificOrigins")]
        [HttpPost]
        public async Task<IActionResult> Create(VideoMD videoMD)
        {
            try
            {
                var vid = await _repo.CreateAsync(videoMD);
                return Ok(vid);
            }
            catch(Exception e)
            {
                return BadRequest(e.ToString());
            }
            
        }
        [EnableCors("MyAllowSpecificOrigins")]
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var vid = await _repo.DeleteAsync(id);
                if (vid == false) return NotFound();
                return Ok("Delete Success!");
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
