using System;
using Xunit;
using Album.Api;
using Album.Api.Services;
using System.Net;

namespace Album.Api.Tests
{
    public class UnitTest1
    {
        GreetingService service = new GreetingService();

        [Fact]
        public void TestWithName()
        {
            Assert.Equal($"Hello Jessey! From {Dns.GetHostName()}", service.Welcome("Jessey"));
        }
        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData(" ")]
        public void TestWithEmptyName(string name)
        {
            Assert.Equal("Hello World!", service.Welcome(name));
        }



    }
}
//