using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using NsccCourseMap.Data;
using NsccCourseMap.Models;

namespace NsccCourseMap_Neo.Pages.AcademicYears
{
  public class IndexModel : PageModel
  {
    private readonly NsccCourseMap.Data.NsccCourseMapContext _context;

    public IndexModel(NsccCourseMap.Data.NsccCourseMapContext context)
    {
      _context = context;
    }

    public IList<AcademicYear> AcademicYear { get; set; }

    public async Task OnGetAsync()
    {
      IQueryable<AcademicYear> sortResult = from ay in _context.AcademicYears
                                            select ay;

      sortResult = sortResult.OrderByDescending(ay => ay.Title);
      AcademicYear = await sortResult.AsNoTracking().ToListAsync();
    }
  }
}
