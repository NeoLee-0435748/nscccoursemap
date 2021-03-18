using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using NsccCourseMap.Data;
using NsccCourseMap.Models;

namespace NsccCourseMap_Neo.Pages.AdvisingAssignments
{
  public class IndexModel : PageModel
  {
    private readonly NsccCourseMap.Data.NsccCourseMapContext _context;

    public IndexModel(NsccCourseMap.Data.NsccCourseMapContext context)
    {
      _context = context;
    }

    public IList<AdvisingAssignment> AdvisingAssignment { get; set; }

    public async Task OnGetAsync()
    {
      IQueryable<AdvisingAssignment> sortResult = from dpy in _context.AdvisingAssignments
                                                  select dpy;

      sortResult = sortResult
        .OrderBy(aa => aa.DiplomaProgramYearSection.DiplomaProgramYear.DiplomaProgram.Title)
        .ThenBy(aa => aa.DiplomaProgramYearSection.DiplomaProgramYear.Title)
        .ThenBy(aa => aa.DiplomaProgramYearSection.Title);
      AdvisingAssignment = await sortResult
        .AsNoTracking()
          .Include(a => a.DiplomaProgramYearSection)
          .Include(a => a.Instructor)
          .Include(a => a.DiplomaProgramYearSection.DiplomaProgramYear.DiplomaProgram)
          .ToListAsync();
    }
  }
}
