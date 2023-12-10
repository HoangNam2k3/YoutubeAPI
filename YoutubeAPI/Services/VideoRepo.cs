﻿using Microsoft.EntityFrameworkCore;
using YoutubeAPI.Data;
using YoutubeAPI.Models;

namespace YoutubeAPI.Services
{
    public class VideoRepo : IRepoVideo
    {
        private readonly MyDbContext _dbContext;

        public VideoRepo(MyDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<VideoVM> CreateAsync(VideoMD videoMD)
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
            return new VideoVM
            {
                video_id = video.video_id,
                category_id = video.category_id,
                channel_id = video.channel_id,
                title = video.title,
                description = video.description,
                thumbnail= video.thumbnail,
                upload_date = video.upload_date,
                url = video.url,
            };
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var video = await _dbContext.Videos.SingleOrDefaultAsync(vid => vid.video_id == id);
            if (video == null) return false;
            _dbContext.Remove(video);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<List<VideoVM>> GetAllAsync()
        {
            var videos = await _dbContext.Videos.Select(video => new VideoVM
            {
                video_id = video.video_id,
                category_id = video.category_id,
                channel_id = video.channel_id,
                title = video.title,
                description = video.description,
                thumbnail = video.thumbnail,
                upload_date = video.upload_date,
                url = video.url,
            }).ToListAsync();
            return videos;
        }

        public async Task<VideoVM> GetByIdAsync(int id)
        {
            var video = await _dbContext.Videos.SingleOrDefaultAsync(vid => vid.video_id == id);
            if (video == null) return null!;
            return new VideoVM
            {
                video_id = video.video_id,
                category_id = video.category_id,
                channel_id = video.channel_id,
                title = video.title,
                description = video.description,
                thumbnail = video.thumbnail,
                upload_date = video.upload_date,
                url = video.url,
            };
        }

        public Task<bool> UpdateAsync(VideoVM videoVM)
        {
            throw new NotImplementedException();
        }
    }
}
