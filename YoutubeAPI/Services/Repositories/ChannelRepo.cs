using AutoMapper;
using Microsoft.EntityFrameworkCore;
using YoutubeAPI.Context;
using YoutubeAPI.DTOs;
using YoutubeAPI.Models;
using YoutubeAPI.Services.Interfaces;

namespace YoutubeAPI.Services.Repositories
{
    public class ChannelRepo : IRepoChannel
    {
        private readonly MyDbContext _dbContext;
        private readonly IMapper _mapper;

        public ChannelRepo(MyDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public async Task<ChannelDto> CreateAsync(ChannelMD channelMD)
        {
            var chan = new Channel
            {
                user_id = channelMD.user_id,
                channel_name = channelMD.channel_name,
                description = channelMD.description,
                avatar = channelMD.avatar,
            };
            _dbContext.Add(chan);
            await _dbContext.SaveChangesAsync();
            return _mapper.Map<ChannelDto>(chan);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var chan = await _dbContext.Channels.SingleOrDefaultAsync(chann => chann.channel_id == id);
            if (chan == null) return false;
            _dbContext.Remove(chan);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<List<ChannelDto>> GetAllAsync()
        {
            var channels = await _dbContext.Channels.Select(channel => _mapper.Map<ChannelDto>(channel))
                .ToListAsync();
            return channels;
        }

        public async Task<ChannelDto> GetByIdAsync(int id)
        {
            var channel = await _dbContext.Channels.SingleOrDefaultAsync(chann => chann.channel_id == id);
            if (channel == null) return null!;
            return _mapper.Map<ChannelDto>(channel);
        }
        public async Task<ChannelDto> GetByUserIdAsync(int user_id)
        {
            var channel = await _dbContext.Channels.SingleOrDefaultAsync(chann => chann.user_id == user_id);
            if (channel == null) return null!;
            return _mapper.Map<ChannelDto>(channel);
        }
        public async Task<bool> UpdateAsync(ChannelDto channelVM)
        {
            var existingChannel = await _dbContext.Channels.FirstOrDefaultAsync(c => c.channel_id == channelVM.channel_id);

            if (existingChannel == null)
            {
                return false;
            }

            _mapper.Map(channelVM, existingChannel);

            _dbContext.Channels.Update(existingChannel);
            await _dbContext.SaveChangesAsync();

            return true;
        }
    }
}
