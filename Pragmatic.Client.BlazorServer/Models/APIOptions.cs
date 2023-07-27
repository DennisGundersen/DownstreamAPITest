namespace Pragmatic.Client.BlazorServer.Models
{
    // Stores API address for simple update in appsettings.json rather than individual pages (registered in DI)
    public class APIOptions
    {
        public string BaseAddress { get; set; }
    }
}
