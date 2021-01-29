using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using NsccCourseMap.Data;

namespace NsccCourseMap_Neo
{
  public class Startup
  {
    public Startup(IConfiguration configuration)
    {
      Configuration = configuration;
    }

    public IConfiguration Configuration { get; }

    public void ConfigureServices(IServiceCollection services)
    {
      services.AddControllersWithViews();
      services.AddRazorPages()
      //Ref: https://wakeupandcode.com/authentication-authorization-in-asp-net-core-3-1/
           .AddRazorPagesOptions(options =>
     {
       //Authentication for razor pages
       //AcademicYears
       options.Conventions.AuthorizePage("/AcademicYears/Create");
       options.Conventions.AuthorizePage("/AcademicYears/Delete");
       options.Conventions.AuthorizePage("/AcademicYears/Details");
       options.Conventions.AuthorizePage("/AcademicYears/Edit");
       options.Conventions.AuthorizePage("/AcademicYears/Index");
       //AdvisingAssignments
       options.Conventions.AuthorizePage("/AdvisingAssignments/Create");
       options.Conventions.AuthorizePage("/AdvisingAssignments/Delete");
       options.Conventions.AuthorizePage("/AdvisingAssignments/Details");
       options.Conventions.AuthorizePage("/AdvisingAssignments/Edit");
       options.Conventions.AuthorizePage("/AdvisingAssignments/Index");
       //CourseOfferings
       options.Conventions.AuthorizePage("/CourseOfferings/Create");
       options.Conventions.AuthorizePage("/CourseOfferings/Delete");
       options.Conventions.AuthorizePage("/CourseOfferings/Details");
       options.Conventions.AuthorizePage("/CourseOfferings/Edit");
       options.Conventions.AuthorizePage("/CourseOfferings/Index");
       //CoursePrerequisites
       options.Conventions.AuthorizePage("/CoursePrerequisites/Create");
       options.Conventions.AuthorizePage("/CoursePrerequisites/Delete");
       options.Conventions.AuthorizePage("/CoursePrerequisites/Details");
       options.Conventions.AuthorizePage("/CoursePrerequisites/Edit");
       options.Conventions.AuthorizePage("/CoursePrerequisites/Index");
       //Courses
       options.Conventions.AuthorizePage("/Courses/Create");
       options.Conventions.AuthorizePage("/Courses/Delete");
       options.Conventions.AuthorizePage("/Courses/Details");
       options.Conventions.AuthorizePage("/Courses/Edit");
       options.Conventions.AuthorizePage("/Courses/Index");
       //DiplomaPrograms
       options.Conventions.AuthorizePage("/DiplomaPrograms/Create");
       options.Conventions.AuthorizePage("/DiplomaPrograms/Delete");
       options.Conventions.AuthorizePage("/DiplomaPrograms/Details");
       options.Conventions.AuthorizePage("/DiplomaPrograms/Edit");
       options.Conventions.AuthorizePage("/DiplomaPrograms/Index");
       //DiplomaProgramYears
       options.Conventions.AuthorizePage("/DiplomaProgramYears/Create");
       options.Conventions.AuthorizePage("/DiplomaProgramYears/Delete");
       options.Conventions.AuthorizePage("/DiplomaProgramYears/Details");
       options.Conventions.AuthorizePage("/DiplomaProgramYears/Edit");
       options.Conventions.AuthorizePage("/DiplomaProgramYears/Index");
       //DiplomaProgramYearSections
       options.Conventions.AuthorizePage("/DiplomaProgramYearSections/Create");
       options.Conventions.AuthorizePage("/DiplomaProgramYearSections/Delete");
       options.Conventions.AuthorizePage("/DiplomaProgramYearSections/Details");
       options.Conventions.AuthorizePage("/DiplomaProgramYearSections/Edit");
       options.Conventions.AuthorizePage("/DiplomaProgramYearSections/Index");
       //Instructors
       options.Conventions.AuthorizePage("/Instructors/Create");
       options.Conventions.AuthorizePage("/Instructors/Delete");
       options.Conventions.AuthorizePage("/Instructors/Details");
       options.Conventions.AuthorizePage("/Instructors/Edit");
       options.Conventions.AuthorizePage("/Instructors/Index");
       //Semesters
       options.Conventions.AuthorizePage("/Semesters/Create");
       options.Conventions.AuthorizePage("/Semesters/Delete");
       options.Conventions.AuthorizePage("/Semesters/Details");
       options.Conventions.AuthorizePage("/Semesters/Edit");
       options.Conventions.AuthorizePage("/Semesters/Index");
       //Main index
       options.Conventions.AllowAnonymousToPage("/Index");
     });

      services.AddDbContext<NsccCourseMapContext>(options =>
        options.UseSqlServer(Configuration.GetConnectionString("NsccCourseMap-Neo")));
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
      if (env.IsDevelopment())
      {
        app.UseDeveloperExceptionPage();
        // app.UseDatabaseErrorPage();
      }
      else
      {
        app.UseExceptionHandler("/Home/Error");
        // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
        app.UseHsts();
      }
      app.UseHttpsRedirection();
      app.UseStaticFiles();

      app.UseRouting();

      app.UseAuthentication();
      app.UseAuthorization();

      app.UseEndpoints(endpoints =>
      {
        endpoints.MapControllerRoute(
              name: "default",
              pattern: "{controller=Home}/{action=Index}/{id?}");
        endpoints.MapRazorPages();
      });
    }
  }
}
