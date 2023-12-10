using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace YoutubeAPI.Data
{
    public class Channel
    {
        public int channel_id { get; set; }
        public string channel_name { get; set; }
        public string? description { get; set; }
        public string? avatar { get; set; }
        public string? background { get; set; }
        public DateTime creation_date { get; set; }

        public int user_id { get; set; }
        public User User { get; set; }

        public virtual ICollection<Video> Videos { get; set; }
        public Channel()
        {
            Videos = new HashSet<Video>();
        }

    }
}
