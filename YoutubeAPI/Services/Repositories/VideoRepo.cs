using AutoMapper;
using Microsoft.EntityFrameworkCore;
using YoutubeAPI.Context;
using YoutubeAPI.DTOs;
using YoutubeAPI.Models;
using YoutubeAPI.Services.Interfaces;

namespace YoutubeAPI.Services.Repositories
{
    public class VideoRepo : IRepoVideo
    {
        private readonly MyDbContext _dbContext;
        private readonly IMapper _mapper;

        public VideoRepo(MyDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public async Task<VideoDto> CreateAsync(VideoMD videoMD)
        {
            var video = new Video
            {
                category_id = videoMD.category_id,
                channel_id = videoMD.channel_id,
                title = videoMD.title,
                description = videoMD.description,
                url = videoMD.url,
                thumbnail = videoMD.thumbnail,
            };
            _dbContext.Add(video);
            await _dbContext.SaveChangesAsync();
            return _mapper.Map<VideoDto>(video);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var video = await _dbContext.Videos.SingleOrDefaultAsync(vid => vid.video_id == id);
            if (video == null) return false;
            _dbContext.Remove(video);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<List<VideoDto>> GetAllAsync()
        {
            var videos = await _dbContext.Videos
                .OrderBy(video => Guid.NewGuid())
                .Select(video => _mapper.Map<VideoDto>(video))
                .ToListAsync();
            return videos;
        }

        public async Task<VideoDto> GetByIdAsync(int id)
        {
            var video = await _dbContext.Videos.SingleOrDefaultAsync(vid => vid.video_id == id);
            if (video == null) return null!;
            return _mapper.Map<VideoDto>(video);
        }
        public async Task<List<VideoDto>> SearchAsync(string query)
        {
            var videos = await _dbContext.Videos
                .Where(vid => vid.title.Contains(query))
                .Select(video => _mapper.Map<VideoDto>(video))
                .ToListAsync();

            return videos;
        }


        public async Task<List<VideoDto>> GetByChannelIdAsync(int channel_id)
        {
            var videos = await _dbContext.Videos
                .Where(video => video.channel_id == channel_id)
                .Select(video => _mapper.Map<VideoDto>(video))
                .ToListAsync();

            return videos;
        }
        public async Task<List<VideoDto>> GetByCategoryIdAsync(int category_id)
        {
            var videos = await _dbContext.Videos
                .Where(video => video.category_id == category_id)
                .Select(video => _mapper.Map<VideoDto>(video))
                .ToListAsync();

            return videos;
        }

        public Task<bool> UpdateAsync(VideoDto videoVM)
        {
            throw new NotImplementedException();
        }
        public async Task<int?> UpdateViewAsync(int id)
        {
            var video = await _dbContext.Videos.SingleOrDefaultAsync(vid => vid.video_id == id);
            if (video == null) return null!;
            video.views = video.views + 10;
            await _dbContext.SaveChangesAsync();
            return video.views;
        }
    }
}
