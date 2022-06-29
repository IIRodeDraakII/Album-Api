using Microsoft.EntityFrameworkCore;

namespace Album.Api
{
    public class AlbumModel 

    {
        public string ID { get; set; }
        public string Name { get; set; }
        public string Artist { get; set; }
        public string ImageUrl { get; set; }

    }
    public class AlbumDbContext : DbContext
    {
        public DbSet<AlbumModel> AlbumModels { get; set; }

        public AlbumDbContext(DbContextOptions<AlbumDbContext> options) : base(options) { }
    }
}





