using YoutubeAPI.DTOs;
using YoutubeAPI.Models;

namespace YoutubeAPI.Helpers
{
    public class Mapper : AutoMapper.Profile
    {
        public Mapper()
        {
            CreateMap<Category, CategoryDto>();
            CreateMap<Channel, ChannelDto>();
            CreateMap<User, UserDto>();
            CreateMap<Video, VideoDto>();

            //
            CreateMap<CategoryDto, Category>();
            CreateMap<ChannelDto, Channel>();
            CreateMap<UserDto, User>();
            CreateMap<VideoDto, Video>();
        }
    }
}
