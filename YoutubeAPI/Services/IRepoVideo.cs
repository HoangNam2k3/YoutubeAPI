using YoutubeAPI.Models;

namespace YoutubeAPI.Services
{
    public interface IRepoVideo
    {
        Task<List<VideoVM>> GetAllAsync(int? perPage = null);
        Task<VideoVM> GetByIdAsync(int id);
        Task<List<VideoVM>> GetByChannelIdAsync(int channel_id);
        Task<List<VideoVM>> GetByCategoryIdAsync(int category_id);
        Task<VideoVM> CreateAsync(VideoMD videoMD);
        Task<bool> UpdateAsync(VideoVM videoVM);
        Task<bool> DeleteAsync(int id);
        Task<int?> UpdateViewAsync(int id);
        Task<List<VideoVM>> SearchAsync(string query);

    }
}
