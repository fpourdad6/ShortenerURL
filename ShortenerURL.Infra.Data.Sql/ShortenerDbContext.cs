using Microsoft.EntityFrameworkCore;
using ShortenerURL.Models;

namespace ShortenerURL.Infra.Data.Sql
{
    public class ShortenerDbContext : DbContext
    {
        public ShortenerDbContext(DbContextOptions<ShortenerDbContext> options) : base(options)
        {
        }
        public DbSet<UrlEntity> UrlEntities { get; set; }

    }
}