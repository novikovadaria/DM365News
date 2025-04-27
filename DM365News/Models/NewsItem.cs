using System.Text.Json.Serialization;

namespace DM365News.Models
{
    public class NewsItem
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Summary { get; set; }
        public DateTime PublishedDate { get; set; }
    }
}
