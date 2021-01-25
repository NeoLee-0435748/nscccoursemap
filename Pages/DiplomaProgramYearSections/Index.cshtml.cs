using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using NsccCourseMap.Data;
using NsccCourseMap.Models;

namespace NsccCourseMap_Neo.Pages.DiplomaProgramYearSections
{
  public class IndexModel : PageModel
  {
    private readonly NsccCourseMap.Data.NsccCourseMapContext _context;

    public IndexModel(NsccCourseMap.Data.NsccCourseMapContext context)
    {
      _context = context;
    }

    public IList<DiplomaProgramYearSection> DiplomaProgramYearSection { get; set; }

    public async Task OnGetAsync()
    {
      IQueryable<DiplomaProgramYearSection> sortResult = from dpys in _context.DiplomaProgramYearSections
                                                         select dpys;

      sortResult = sortResult
        .OrderByDescending(dpys => dpys.AcademicYear.Title)
        .ThenBy(dpys => dpys.DiplomaProgramYear.Title)
        .ThenBy(dpys => dpys.Title);
      DiplomaProgramYearSection = await sortResult
        .AsNoTracking()
        .Include(d => d.AcademicYear)
        .Include(d => d.DiplomaProgramYear)
        .Include(d => d.DiplomaProgramYear.DiplomaProgram)
        .ToListAsync();
    }
  }
}
