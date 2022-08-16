using Microsoft.EntityFrameworkCore;

namespace ShortenerURL.Models
{
    [Index(nameof(UrlKey), IsUnique = true)]
    [Index(nameof(UrlId), IsUnique = true)]
    public class UrlEntity
    {
        public int Id { get; set; }
        public int UrlId { get; set; }
        public string UrlKey { get; set; }
        public string LongUrl { get; set; }
    }
}
