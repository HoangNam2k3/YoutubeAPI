using Microsoft.EntityFrameworkCore;
using YoutubeAPI.Data;
using YoutubeAPI.Models;

namespace YoutubeAPI.Services
{
    public class ChannelRepo :IRepoChannel
    {
        private readonly MyDbContext _dbContext;

        public ChannelRepo(MyDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<ChannelVM> CreateAsync(ChannelMD channelMD)
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
            return new ChannelVM
            {
                channel_id = chan.channel_id,
                background = chan.background,
                creation_date = chan.creation_date,
                user_id = chan.user_id,
                channel_name = chan.channel_name,
                description = chan.description,
                avatar = chan.avatar,
            };
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var chan = await _dbContext.Channels.SingleOrDefaultAsync(chann => chann.channel_id == id);
            if (chan == null) return false;
            _dbContext.Remove(chan);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<List<ChannelVM>> GetAllAsync()
        {
            var channels = await _dbContext.Channels.Select(channel => new ChannelVM
            {
                channel_id = channel.channel_id,
                user_id = channel.user_id,
                channel_name = channel.channel_name,
                description = channel.description,
                avatar = channel.avatar,
                background = channel.background,
                creation_date = channel.creation_date,
            }).ToListAsync();
            return channels;
        }

        public async Task<ChannelVM> GetByIdAsync(int id)
        {
            var channel = await _dbContext.Channels.SingleOrDefaultAsync(chann => chann.channel_id == id);
            if (channel == null) return null!;
            return new ChannelVM
            {
                channel_id = channel.channel_id,
                user_id = channel.user_id,
                channel_name = channel.channel_name,
                description = channel.description,
                avatar = channel.avatar,
                background = channel.background,
                creation_date = channel.creation_date,
            };
        }
        public async Task<ChannelVM> GetByUserIdAsync(int user_id)
        {
            var channel = await _dbContext.Channels.SingleOrDefaultAsync(chann => chann.user_id == user_id);
            if (channel == null) return null!;
            return new ChannelVM
            {
                channel_id = channel.channel_id,
                user_id = channel.user_id,
                channel_name = channel.channel_name,
                description = channel.description,
                avatar = channel.avatar,
                background = channel.background,
                creation_date = channel.creation_date,
            };
        }
        public async Task<bool> UpdateAsync(ChannelVM channelVM)
        {
            var existingChannel = await _dbContext.Channels.FirstOrDefaultAsync(c => c.channel_id == channelVM.channel_id);

            if (existingChannel == null)
            {
                return false;
            }

            existingChannel.user_id = channelVM.user_id;
            existingChannel.channel_name = channelVM.channel_name;
            existingChannel.description = channelVM.description;
            existingChannel.avatar = channelVM.avatar;
            existingChannel.background = channelVM.background;
            existingChannel.creation_date = channelVM.creation_date;

            _dbContext.Channels.Update(existingChannel);
            await _dbContext.SaveChangesAsync();

            return true;
        }

    }
}
