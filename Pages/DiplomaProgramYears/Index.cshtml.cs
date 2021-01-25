using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using NsccCourseMap.Data;
using NsccCourseMap.Models;

namespace NsccCourseMap_Neo.Pages.DiplomaProgramYears
{
  public class IndexModel : PageModel
  {
    private readonly NsccCourseMap.Data.NsccCourseMapContext _context;

    public IndexModel(NsccCourseMap.Data.NsccCourseMapContext context)
    {
      _context = context;
    }

    public IList<DiplomaProgramYear> DiplomaProgramYear { get; set; }

    public async Task OnGetAsync()
    {
      IQueryable<DiplomaProgramYear> sortResult = from dpy in _context.DiplomaProgramYears
                                                  select dpy;

      sortResult = sortResult.OrderBy(dpy => dpy.DiplomaProgram.Title).ThenBy(dpy => dpy.Title);
      DiplomaProgramYear = await sortResult.AsNoTracking().Include(d => d.DiplomaProgram).ToListAsync();
    }
  }
}
