using System.Net;

namespace Album.Api.Services
{
    public class GreetingService
    {
        public string Welcome(string name)
        {
            if (string.IsNullOrWhiteSpace(name)) return $"Hello World!  From {Dns.GetHostName()} V2";
            return $"Hello {name}! From {Dns.GetHostName()} V2";
        }
    }
}
