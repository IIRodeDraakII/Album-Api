using Xunit;
using Microsoft.EntityFrameworkCore;
using Album.Api.Services;

namespace Album.Api.Tests
{
    public class UnitTestService
    {
        [Fact]
        public async void DeleteAlbum()
        {
            var test = new AlbumModel { ID = "1", Name = "Jessey", Artist = "Jessey", ImageUrl = "Jessey" };

            var options = new DbContextOptionsBuilder<AlbumDbContext>()
                    .UseInMemoryDatabase(databaseName: "AlbumTest")
                    .Options;

            var context = new AlbumDbContext(options);

            context.Database.EnsureDeleted();
            context.AlbumModels.Add(test);
            context.SaveChanges();

            AlbumService service = new AlbumService(context);


            var res = service.GetAlbum("1");
            Assert.Equal(test, res);
            await service.DeleteAlbum("1");

            Assert.False(service.AlbumModelExists("1"));
        }
        [Fact]
        public void GetAlbums()
        {
            var test = new AlbumModel { ID = "2", Name = "Jessey", Artist = "Jessey", ImageUrl = "Jessey" };
            var test2 = new AlbumModel { ID = "3", Name = "Jessey", Artist = "Jessey", ImageUrl = "Jessey" };
            var options = new DbContextOptionsBuilder<AlbumDbContext>()
                    .UseInMemoryDatabase(databaseName: "AlbumTestAlbumss")
                    .Options;

            var context = new AlbumDbContext(options);

            context.Database.EnsureDeleted();
            context.AlbumModels.Add(test);
            context.AlbumModels.Add(test2);
            context.SaveChanges();

            AlbumService service = new AlbumService(context);

            var res = service.GetAlbums();
            Assert.Equal(test, res[0]);
            Assert.Equal(test2, res[1]);
        }
        [Fact]
        public void GetAlbum()
        {
            var test = new AlbumModel { ID = "4", Name = "Jessey", Artist = "Jessey", ImageUrl = "Jessey" };

            var options = new DbContextOptionsBuilder<AlbumDbContext>()
                    .UseInMemoryDatabase(databaseName: "AlbumTest")
                    .Options;

            var context = new AlbumDbContext(options);

            context.Database.EnsureDeleted();
            context.AlbumModels.Add(test);
            context.SaveChanges();

            AlbumService service = new AlbumService(context);

            var res = service.GetAlbum("4");
            Assert.Equal(test, res);
        }

        [Fact]
        public async void PostAlbum()
        {
            var test = new AlbumModel { ID = "5", Name = "Jessey", Artist = "Jessey", ImageUrl = "Jessey" };

            var options = new DbContextOptionsBuilder<AlbumDbContext>()
                    .UseInMemoryDatabase(databaseName: "AlbumTest")
                    .Options;

            var context = new AlbumDbContext(options);

            context.Database.EnsureDeleted();
            context.SaveChanges();

            AlbumService service = new AlbumService(context);


            await service.PostAlbum(test);
            var res = service.GetAlbum("5");
            Assert.Equal(test, res);
        }
        [Fact]
        public async void PutAlbum()
        {
            var test = new AlbumModel { ID = "6", Name = "Jessey", Artist = "Jessey", ImageUrl = "Jessey" };

            var options = new DbContextOptionsBuilder<AlbumDbContext>()
                    .UseInMemoryDatabase(databaseName: "AlbumTest")
                    .Options;

            var context = new AlbumDbContext(options);

            context.Database.EnsureDeleted();
            context.SaveChanges();

            AlbumService service = new AlbumService(context);


            await service.PutAlbum("6", test);
            var res = service.GetAlbum("6");
            Assert.Equal(test, res);
        }

        [Fact]
        public async void UpdateAsync()
        {
            var test = new AlbumModel { ID = "7", Name = "Jessey", Artist = "Jessey", ImageUrl = "Jessey" };

            var options = new DbContextOptionsBuilder<AlbumDbContext>()
                    .UseInMemoryDatabase(databaseName: "AlbumTest")
                    .Options;

            var context = new AlbumDbContext(options);

            context.Database.EnsureDeleted();
            context.SaveChanges();

            AlbumService service = new AlbumService(context);


            await service.UpdateAsync("7", test);
            var res = service.GetAlbum("7");
            Assert.Equal(test, res);
        }

        [Fact]
        public async void AlbumModelExists()
        {
            var test = new AlbumModel { ID = "8", Name = "Jessey", Artist = "Jessey", ImageUrl = "Jessey" };

            var options = new DbContextOptionsBuilder<AlbumDbContext>()
                    .UseInMemoryDatabase(databaseName: "AlbumTest")
                    .Options;

            var context = new AlbumDbContext(options);

            context.Database.EnsureDeleted();
            context.AlbumModels.Add(test);
            context.SaveChanges();

            AlbumService service = new AlbumService(context);
            Assert.True(service.AlbumModelExists("8"));
        }

    }
}