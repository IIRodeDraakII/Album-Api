using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using System.Threading;
using System.Threading.Tasks;

namespace Album.Api.Controllers
{
    [Route("/health")]
    [ApiController]
    public class HealthController : Controller
    {


        [HttpGet]
            public Task<HealthCheckResult> CheckHealthAsync()
        {
                return Task.FromResult(
                    HealthCheckResult.Healthy("A healthy result."));
            
        }
    }
}
//
