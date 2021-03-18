using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NsccCourseMap_Neo.Areas.Identity.Data;

[assembly: HostingStartup(typeof(NsccCourseMap_Neo.Areas.Identity.IdentityHostingStartup))]
namespace NsccCourseMap_Neo.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<NsccCourseMap_NeoIdentityDbContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("NsccCourseMap_NeoIdentityDbContextConnection")));

                services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
                    .AddEntityFrameworkStores<NsccCourseMap_NeoIdentityDbContext>();
            });
        }
    }
}