using Album.Api.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Album.Api
{
    [Route("api/[controller]")]
    [ApiController]


    public class HelloController : ControllerBase
    {
        private readonly GreetingService _service;
        public HelloController( GreetingService service)
        {

            _service = service;
        }

        [HttpGet] //api/hello
        public string Get(string name)
        {
            return _service.Welcome(name);            
        }

    }
}
    