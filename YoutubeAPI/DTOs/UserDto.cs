namespace YoutubeAPI.DTOs
{
    public class UserMD
    {
        public string username { get; set; }
        public string email { get; set; }
        public string password { get; set; }
    }
    public class UserDto : UserMD
    {
        public int user_id { get; set; }
        public DateTime join_date { get; set; }

    }
}
