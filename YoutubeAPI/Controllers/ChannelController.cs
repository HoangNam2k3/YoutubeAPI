using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using YoutubeAPI.DTOs;
using YoutubeAPI.Services.Interfaces;

namespace YoutubeAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChannelController : ControllerBase
    {
        private readonly IRepoChannel _repo;

        public ChannelController(IRepoChannel repo)
        {
            _repo = repo;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var channels = await _repo.GetAllAsync();
                return Ok(channels);
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
                var channel = await _repo.GetByIdAsync(id);
                if (channel == null) return NotFound();
                return Ok(channel);
            }
            catch
            {
                return BadRequest();
            }
        }
        [EnableCors("MyAllowSpecificOrigins")]
        [HttpGet("user/{userId}", Name = "GetChannelByUserId")]
        public async Task<IActionResult> GetByUserId(int userId)
        {
            try
            {
                var channel = await _repo.GetByUserIdAsync(userId);
                return Ok(channel);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [EnableCors("MyAllowSpecificOrigins")]
        [HttpPost]
        public async Task<IActionResult> Create(ChannelMD channelMD)
        {
            try
            {
                var channel = await _repo.CreateAsync(channelMD);
                return Ok(channel);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }
        [EnableCors("MyAllowSpecificOrigins")]
        [HttpPut]
        public async Task<IActionResult> Update(ChannelDto channelVM)
        {
            try
            {
                var isUpdate = await _repo.UpdateAsync(channelVM);
                return Ok(isUpdate);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var channel = await _repo.DeleteAsync(id);
                if (channel == false) return NotFound();
                return Ok("Delete Success!");
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}