namespace YoutubeAPI.Models
{
    public class ChannelMD
    {
        public int user_id { get; set; }
        public string channel_name { get; set; }
        public string description { get; set; }
        public string avatar { get; set; }
    }
    public class ChannelVM : ChannelMD
    {
        public int channel_id { get; set; }
        public string background { get; set; }
        public DateTime creation_date { get; set; }
    }
}
