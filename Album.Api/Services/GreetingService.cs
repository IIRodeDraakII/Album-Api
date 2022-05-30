namespace Album.Api.Services
{
    public class GreetingService
    {
        public string Welcome(string name)
        {
            if (string.IsNullOrWhiteSpace(name)) return "Hello World!";
            return $"Hello {name}!";
        }
    }
}
