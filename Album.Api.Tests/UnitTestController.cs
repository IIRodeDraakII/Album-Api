using System;

using System.Threading.Tasks;


using Xunit;

using Microsoft.EntityFrameworkCore;

using Album.Api.Controllers;

using Album.Api.Services;

using Microsoft.AspNetCore.Mvc;



namespace Album.Api.Tests
{
    public class UnitTestController
    {
        [Fact]
        public void GetAlbum()
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
            AlbumController controller = new AlbumController(service);

            var res = controller.GetAlbum("1").Value;
            Assert.Equal(test, res);
        }
        [Fact]
        public void GetNotExistingAlbum()
        {
            var options = new DbContextOptionsBuilder<AlbumDbContext>()
                    .UseInMemoryDatabase(databaseName: "AlbumTest")
                    .Options;

            var context = new AlbumDbContext(options);

            context.Database.EnsureDeleted();
            context.SaveChanges();

            AlbumService service = new AlbumService(context);
            AlbumController controller = new AlbumController(service);
            var res2 = controller.GetAlbum("0").Result as ObjectResult;
            Assert.Equal("Not Found", res2.Value.ToString());
        }
        [Fact]
        public void GetAlbums()
        {
            var test = new AlbumModel { ID = "2", Name = "Jessey", Artist = "Jessey", ImageUrl = "Jessey" };
            var test2 = new AlbumModel { ID = "3", Name = "Jessey", Artist = "Jessey", ImageUrl = "Jessey" };
            var options = new DbContextOptionsBuilder<AlbumDbContext>()
                    .UseInMemoryDatabase(databaseName: "AlbumTestAlbums2")
                    .Options;

            var context = new AlbumDbContext(options);

            context.Database.EnsureDeleted();
            context.AlbumModels.Add(test);
            context.AlbumModels.Add(test2);
            context.SaveChanges();

            AlbumService service = new AlbumService(context);
            AlbumController controller = new AlbumController(service);
            var check1 = controller.GetAlbums().Value[0] as Object;
            var check2 = controller.GetAlbums().Value[1] as Object;
            Assert.Equal(test, check1);
            Assert.Equal(test2, check2);

        }
        [Fact]
        public async Task PutAlbumAlreadyExists()
        {
            var test = new AlbumModel { ID = "4", Name = "Jessey", Artist = "Jessey", ImageUrl = "Jessey" };
            var options = new DbContextOptionsBuilder<AlbumDbContext>()
                    .UseInMemoryDatabase(databaseName: "AlbumTestAlbums")
                    .Options;

            var context = new AlbumDbContext(options);

            context.Database.EnsureDeleted();
            context.AlbumModels.Add(test);
            context.SaveChanges();

            AlbumService service = new AlbumService(context);
            AlbumController controller = new AlbumController(service);
            var check1 = await controller.PutAlbum("0", test) as ObjectResult;
            Assert.Equal("Bestaat al", check1.Value);

        }

        [Fact]
        public async Task PutAlbumWorks()
        {
            var test = new AlbumModel { ID = "5", Name = "Jessey", Artist = "Jessey", ImageUrl = "Jessey" };
            var options = new DbContextOptionsBuilder<AlbumDbContext>()
                    .UseInMemoryDatabase(databaseName: "AlbumTestAlbums")
                    .Options;

            var context = new AlbumDbContext(options);

            context.Database.EnsureDeleted();
            context.AlbumModels.Add(test);
            context.SaveChanges();

            AlbumService service = new AlbumService(context);
            AlbumController controller = new AlbumController(service);
            var check1 = await controller.PutAlbum("5", test) as ObjectResult;
            Assert.Equal("Works", check1.Value);
        }

        [Fact]
        public async Task PostAlbum()
        {
            var test = new AlbumModel { ID = "8", Name = "Jessey", Artist = "Jessey", ImageUrl = "Jessey" };
            var options = new DbContextOptionsBuilder<AlbumDbContext>()
                    .UseInMemoryDatabase(databaseName: "AlbumTestAlbums")
                    .Options;

            var context = new AlbumDbContext(options);

            context.Database.EnsureDeleted();
            context.SaveChanges();

            AlbumService service = new AlbumService(context);
            AlbumController controller = new AlbumController(service);
            var check1 = (await controller.PostAlbum(test)).Value.ToString();
            Assert.Equal("Succes", check1);
        }

        [Fact]
        public async Task PostAlbumAlreadyExists()
        {
            var test = new AlbumModel { ID = "7", Name = "Jessey", Artist = "Jessey", ImageUrl = "Jessey" };
            var test1 = new AlbumModel { ID = "7", Name = "Jessey", Artist = "Jessey", ImageUrl = "Jessey" };
            var options = new DbContextOptionsBuilder<AlbumDbContext>()
                    .UseInMemoryDatabase(databaseName: "AlbumTestAlbums")
                    .Options;

            var context = new AlbumDbContext(options);

            context.Database.EnsureDeleted();
            context.AlbumModels.Add(test);
            context.SaveChanges();

            AlbumService service = new AlbumService(context);
            AlbumController controller = new AlbumController(service);
            var check1 = (await controller.PostAlbum(test1)).Value.ToString();
            Assert.Equal("Bestaat al", check1);
        }

        [Fact]
        public async Task DeleteAlbum()
        {
            var test = new AlbumModel { ID = "9", Name = "Jessey", Artist = "Jessey", ImageUrl = "Jessey" };
            var options = new DbContextOptionsBuilder<AlbumDbContext>()
                    .UseInMemoryDatabase(databaseName: "AlbumTestAlbums")
                    .Options;

            var context = new AlbumDbContext(options);

            context.Database.EnsureDeleted();
            context.AlbumModels.Add(test);
            context.SaveChanges();

            AlbumService service = new AlbumService(context);
            AlbumController controller = new AlbumController(service);
            var check1 = (await controller.DeleteAlbum("9")) as ObjectResult;
            Assert.Equal("Verwijderd", check1.Value.ToString());
        }

        [Fact]
        public async Task DeleteAlbumNotFound()
        {
            var options = new DbContextOptionsBuilder<AlbumDbContext>()
                    .UseInMemoryDatabase(databaseName: "AlbumTestAlbums")
                    .Options;

            var context = new AlbumDbContext(options);

            context.Database.EnsureDeleted();
            context.SaveChanges();

            AlbumService service = new AlbumService(context);
            AlbumController controller = new AlbumController(service);
            var check1 = (await controller.DeleteAlbum("10")) as ObjectResult;
            Assert.Equal("Niet gevonden", check1.Value.ToString());
        }
    }
}