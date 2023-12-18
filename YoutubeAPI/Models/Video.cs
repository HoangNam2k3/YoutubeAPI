namespace YoutubeAPI.Models
{
    public class Video
    {
        public int video_id { get; set; }
        public string title { get; set; }
        public string? description { get; set; }
        public string url { get; set; }
        public string? thumbnail { get; set; }
        public int views { get; set; }
        public DateTime upload_date { get; set; }

        public int channel_id { get; set; }
        public Channel Channel { get; set; }
        public int category_id { get; set; }
        public Category Category { get; set; }
    }
}
