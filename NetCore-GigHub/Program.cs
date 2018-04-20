using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;

namespace NetCore_GigHub
{
    public class Program
    {
        public static void Main(string[] args)
        {
            BuildWebHost(args).Run();
        }

        public static IWebHost BuildWebHost(string[] args) =>
        WebHost.CreateDefaultBuilder(args)
            .ConfigureAppConfiguration((ctx, builder) =>
            {
                builder.Sources.Clear();
                builder.AddJsonFile("config.json", optional: false, reloadOnChange: true)
                    .AddEnvironmentVariables();
            })
            .UseStartup<Startup>()
            .Build();
    }
}
