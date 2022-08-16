namespace ShortenerURL.Models
{
    public interface IShortenerUrl
    {
        UrlEntity? Get(string shortUrl);
        UrlEntity Add(string longUrl);
        UrlEntity GenerateUrlEntity(string longUrl);
    }
}
