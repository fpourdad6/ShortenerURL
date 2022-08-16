using Microsoft.AspNetCore.WebUtilities;

namespace ShortenerURL.Models;
public class UrlDto
{
    
    public int Id { get; set; }
    public string LongUrl { get; set; }
    public string ShortUrl => WebEncoders.Base64UrlEncode(BitConverter.GetBytes(Id));
    public UrlDto(Uri url)
    {
        LongUrl = url.ToString();

    }

}