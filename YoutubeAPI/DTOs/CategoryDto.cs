namespace YoutubeAPI.DTOs
{
    public class CategoryMD
    {
        public string category_name { get; set; }
    }
    public class CategoryDto : CategoryMD
    {
        public int category_id { get; set; }
    }
}
