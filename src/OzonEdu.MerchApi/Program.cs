using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using OzonEdu.Platform.Infrastructure.Extensions;

namespace OzonEdu.MerchApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                })
                .AddInfrastructure();
    }
}