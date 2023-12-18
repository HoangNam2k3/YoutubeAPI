namespace YoutubeAPI.Models
{
    public class Category
    {
        public int category_id { get; set; }
        public string category_name { get; set; }
        public virtual ICollection<Video> Videos { get; set; }
        public Category()
        {
            Videos = new HashSet<Video>();
        }
    }
}
