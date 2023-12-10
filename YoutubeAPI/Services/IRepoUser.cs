using YoutubeAPI.Models;

namespace YoutubeAPI.Services
{
    public interface IRepoUser
    {
        Task<List<UserVM>> GetAllAsync();
        Task<UserVM> GetByIdAsync(int id);
        Task<UserVM> CreateAsync(UserMD userMD);
        Task<bool> UpdateAsync(UserVM userVM);
        Task<UserVM> CheckCredentialsAsync(string email, string password);

        Task<bool> DeleteAsync(int id);
    }
}
