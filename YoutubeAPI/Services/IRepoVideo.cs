using YoutubeAPI.Models;

namespace YoutubeAPI.Services
{
    public interface IRepoVideo
    {
        Task<List<VideoVM>> GetAllAsync();
        Task<VideoVM> GetByIdAsync(int id);
        Task<VideoVM> CreateAsync(VideoMD videoMD);
        Task<bool> UpdateAsync(VideoVM videoVM);
        Task<bool> DeleteAsync(int id);
    }
}
