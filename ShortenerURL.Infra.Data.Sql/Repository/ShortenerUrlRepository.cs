using Microsoft.AspNetCore.WebUtilities;
using ShortenerURL.Infra.Data.Sql;

namespace ShortenerURL.Models
{
    public class ShortenerUrlRepository :IShortenerUrl
    {
        private readonly ShortenerDbContext shortenerDbContext;
        public static int urlId = 0;

        public ShortenerUrlRepository(ShortenerDbContext shortenerDbContext)
        {
            this.shortenerDbContext = shortenerDbContext;
        }
        public UrlEntity? Get(string shortUrl)
        {
            return shortenerDbContext.UrlEntities.FirstOrDefault(a => a.UrlKey == shortUrl);
        }
        public UrlEntity Add(string longUrl)
        {
            var entity = GenerateUrlEntity(longUrl);
            shortenerDbContext.UrlEntities.Add(entity);
            shortenerDbContext.SaveChanges();
            return entity;
        }
        public UrlEntity GenerateUrlEntity(string longUrl)
        {
            if (Store.Id ==0)
            {
                var rnd = new Random(DateTime.Now.Second);
                Store.Id = rnd.Next();
            };
            var entity = new UrlEntity
            {
                UrlId = Store.Id,
                UrlKey = WebEncoders.Base64UrlEncode(BitConverter.GetBytes(Store.Id)),
                LongUrl = longUrl
            };
            Store.Id++;
            return entity;
        }
    }
}
