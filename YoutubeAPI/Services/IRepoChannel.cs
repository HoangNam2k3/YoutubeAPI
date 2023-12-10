using YoutubeAPI.Models;

namespace YoutubeAPI.Services
{
    public interface IRepoChannel
    {
        Task<List<ChannelVM>> GetAllAsync();
        Task<ChannelVM> GetByIdAsync(int id);
        Task<ChannelVM> CreateAsync(ChannelMD channelMD);
        Task<bool> UpdateAsync(ChannelVM channelVM);
        Task<bool> DeleteAsync(int id);
        Task<ChannelVM> GetByUserIdAsync(int user_id);
    }
}
