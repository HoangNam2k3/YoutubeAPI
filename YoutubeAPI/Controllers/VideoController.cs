using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using YoutubeAPI.DTOs;
using YoutubeAPI.Services.Interfaces;

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
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
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
        [HttpGet("channel/{channel_id}", Name = "GetVideoByChannelId")]
        public async Task<IActionResult> GetByChannelId(int channel_id)
        {
            try
            {
                var vids = await _repo.GetByChannelIdAsync(channel_id);
                return Ok(vids);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.ToString());
            }
           
        }
        [EnableCors("MyAllowSpecificOrigins")]
        [HttpGet("category")]
        public async Task<IActionResult> GetByCategoryId(int category_id)
        {
            try
            {
                var vids = await _repo.GetByCategoryIdAsync(category_id);
                return Ok(vids);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }

        }
        [EnableCors("MyAllowSpecificOrigins")]
        [HttpPost("search")]
        public async Task<IActionResult> Search(string query)
        {
            try
            {
                var vids = await _repo.SearchAsync(query);
                return Ok(vids);
            }catch(Exception ex)
            {
                return BadRequest(ex.ToString());
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
        [HttpPatch("view/update/{id}")]
        public async Task<IActionResult> UpdateView(int id)
        {
            try
            {
                var views = await _repo.UpdateViewAsync(id);
                if(views == null) return NotFound();
                return Ok(views);
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

//public async Task<IActionResult> GetAll(int? numberOfVideos = null)
//{
//    try
//    {
//        var vids = await _repo.GetAllAsync(numberOfVideos);
//        return Ok(vids);
//    }
//    catch (Exception ex)
//    {
//        return BadRequest(ex.ToString());
//    }
//}