using Microsoft.AspNetCore.Hosting;

[assembly: HostingStartup(typeof(Test.Areas.Identity.IdentityHostingStartup))]
namespace Test.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) =>
            {
            });
        }
    }
}