using YoutubeAPI.DTOs;

namespace YoutubeAPI.Services.Interfaces
{
    public interface IRepoChannel : IRepo<ChannelDto, ChannelMD>
    {
        Task<ChannelDto> GetByUserIdAsync(int user_id);
    }
}
