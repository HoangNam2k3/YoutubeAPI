using Microsoft.EntityFrameworkCore;

namespace YoutubeAPI.Data
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions options) : base(options) { }

        #region DbSet
        public DbSet<User> Users { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Channel> Channels { get; set; }
        public DbSet<Video> Videos { get; set; }
        #endregion

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<User>(e =>
            {
                e.HasKey(us => us.user_id);
                e.Property(us => us.join_date).HasDefaultValueSql("GetDate()");
            });
            modelBuilder.Entity<Category>(e =>
            {
                e.HasKey(cat => cat.category_id);
            });
            modelBuilder.Entity<Channel>(e =>
            {
                e.HasKey(chan => chan.channel_id);
                e.HasOne(chan => chan.User)
                .WithOne(chan => chan.Channel)
                .HasForeignKey<Channel>(chan => chan.user_id);
                e.Property(chan => chan.creation_date).HasDefaultValueSql("GetDate()");
                e.Property(chan => chan.background).IsRequired(false);
                e.Property(chan => chan.avatar).IsRequired(false);
                e.Property(chan => chan.description).IsRequired(false);
            });
            modelBuilder.Entity<Video>(e =>
            {
                e.HasKey(vid => vid.video_id);
                e.HasOne(vid => vid.Channel)
                .WithMany(vid => vid.Videos)
                .HasForeignKey(vid => vid.channel_id);

                e.HasOne(vid => vid.Category)
                .WithMany(vid => vid.Videos)
                .HasForeignKey(vid => vid.category_id);

                e.Property(vid => vid.views).HasDefaultValue(0);
                e.Property(vid => vid.upload_date).HasDefaultValueSql("GetDate()");
                e.Property(vid => vid.description).IsRequired(false);
                e.Property(vid => vid.thumbnail).IsRequired(false);
            });
        }
    }
}
