using YoutubeAPI.DTOs;

namespace YoutubeAPI.Services.Interfaces
{
    public interface IRepoVideo : IRepo<VideoDto, VideoMD>
    {
        Task<List<VideoDto>> GetByChannelIdAsync(int channel_id);
        Task<List<VideoDto>> GetByCategoryIdAsync(int category_id);
        Task<int?> UpdateViewAsync(int id);
        Task<List<VideoDto>> SearchAsync(string query);

    }
}
