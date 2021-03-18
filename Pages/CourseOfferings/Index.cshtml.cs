using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using NsccCourseMap.Data;
using NsccCourseMap.Models;

namespace NsccCourseMap_Neo.Pages.CourseOfferings
{
  public class IndexModel : PageModel
  {
    private readonly NsccCourseMap.Data.NsccCourseMapContext _context;

    public IndexModel(NsccCourseMap.Data.NsccCourseMapContext context)
    {
      _context = context;
    }

    public IList<CourseOffering> CourseOffering { get; set; }

    public async Task OnGetAsync()
    {
      IQueryable<CourseOffering> sortResult = from co in _context.CourseOfferings
                                              select co;

      sortResult = sortResult
        .OrderByDescending(co => co.Semester.Name)
        .ThenBy(co => co.DiplomaProgramYearSection.DiplomaProgramYear.DiplomaProgram.Title)
        .ThenBy(co => co.DiplomaProgramYearSection.DiplomaProgramYear.Title)
        .ThenBy(co => co.Course.CourseCode);
      CourseOffering = await sortResult
          .Include(c => c.Course)
          .Include(c => c.DiplomaProgramYearSection)
          .Include(c => c.Instructor)
          .Include(c => c.Semester)
          .Include(c => c.DiplomaProgramYearSection.DiplomaProgramYear.DiplomaProgram)
          .ToListAsync();
    }
  }
}
