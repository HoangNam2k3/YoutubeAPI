using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using YoutubeAPI.Models;
using YoutubeAPI.Services;

namespace YoutubeAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IRepoUser _repo;

        public UserController(IRepoUser repo)
        {
            _repo = repo;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var users = await _repo.GetAllAsync();
                return Ok(users);
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
                var user = await _repo.GetByIdAsync(id);
                if (user == null) return NotFound();
                return Ok(user);
            }
            catch
            {
                return BadRequest();
            }
        }
        [EnableCors("MyAllowSpecificOrigins")]
        [HttpPost]
        public async Task<IActionResult> Create(UserMD userMD)
        {
            try
            {
                var user = await _repo.CreateAsync(userMD);
                return Ok(user);
            }
            catch (Exception e)
            {
                return BadRequest(e.ToString()); // Convert exception to string for detailed information
            }
        }
        [EnableCors("MyAllowSpecificOrigins")]
        [HttpPost("login")]
        public async Task<IActionResult> Login(string email, string password)
        {
            try
            {
                var user = await _repo.CheckCredentialsAsync(email, password);
                return Ok(user);
            }
            catch(Exception e)
            {
                return BadRequest(e.ToString());
            }
        }
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var user = await _repo.DeleteAsync(id);
                if (user == false) return NotFound();
                return Ok("Delete Success!");
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
