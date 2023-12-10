namespace YoutubeAPI.Models
{
    public class CategoryMD
    {
        public string category_name { get; set; }
    }
    public class CategoryVM : CategoryMD
    {
        public int category_id { get; set; }
    }
}
