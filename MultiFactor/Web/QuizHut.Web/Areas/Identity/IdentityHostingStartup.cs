using Microsoft.AspNetCore.Hosting;

[assembly: HostingStartup(typeof(MultiFactor.Web.Areas.Identity.IdentityHostingStartup))]

namespace MultiFactor.Web.Areas.Identity
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
