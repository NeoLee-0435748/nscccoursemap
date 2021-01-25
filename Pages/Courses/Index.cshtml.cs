using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using NsccCourseMap.Data;
using NsccCourseMap.Models;

//Ref: https://docs.microsoft.com/en-us/aspnet/core/data/ef-rp/sort-filter-page?view=aspnetcore-5.0#add-sorting
namespace NsccCourseMap_Neo.Pages.Courses
{
  public class IndexModel : PageModel
  {
    private readonly NsccCourseMap.Data.NsccCourseMapContext _context;

    public IndexModel(NsccCourseMap.Data.NsccCourseMapContext context)
    {
      _context = context;
    }

    public IList<Course> Course { get; set; }

    public async Task OnGetAsync()
    {
      IQueryable<Course> sortResult = from c in _context.Courses
                                      select c;

      sortResult = sortResult.OrderBy(c => c.CourseCode);
      Course = await sortResult.AsNoTracking().ToListAsync();
    }
  }
}
