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
      builder.ConfigureServices((context, services) =>
      {
        services.AddDbContext<NsccCourseMap_NeoIdentityDbContext>(options =>
        {
          var env = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
          string connStr;

          if (env == "Development")
          {
            connStr = context.Configuration.GetConnectionString("NsccCourseMap_NeoIdentityDbContextConnection_Mysql");
          }
          else
          {
            // Use connection string provided at runtime by Heroku.
            var connUrl = Environment.GetEnvironmentVariable("JAWSDB_URL");

            connUrl = connUrl.Replace("mysql://", string.Empty);
            connUrl = connUrl.Replace(":3306", string.Empty);
            var userPassSide = connUrl.Split("@")[0];
            var hostSide = connUrl.Split("@")[1];

            var connUser = userPassSide.Split(":")[0];
            var connPass = userPassSide.Split(":")[1];
            var connHost = hostSide.Split("/")[0];
            var connDb = hostSide.Split("/")[1];

            connStr = $"server={connHost};Uid={connUser};Pwd={connPass};Database={connDb}";
          }

          options.UseMySql(connStr, ServerVersion.AutoDetect(connStr));
        });

        services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
            .AddEntityFrameworkStores<NsccCourseMap_NeoIdentityDbContext>();
      });
    }
  }
}