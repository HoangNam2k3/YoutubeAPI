using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace YoutubeAPI.Data
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
