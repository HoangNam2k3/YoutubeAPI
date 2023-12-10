namespace YoutubeAPI.Models
{
    public class UserMD
    {
        public string username { get; set; }
        public string email { get; set; }
        public string password { get; set; }
    }
    public class UserVM : UserMD
    {
        public int user_id { get; set; }
        public DateTime join_date { get; set; }

    }
}
