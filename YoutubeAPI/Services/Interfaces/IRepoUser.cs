using YoutubeAPI.DTOs;

namespace YoutubeAPI.Services.Interfaces
{
    public interface IRepoUser : IRepo<UserDto, UserMD>
    {
        Task<UserDto> CheckCredentialsAsync(string email, string password);

    }
}
