using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using NsccCourseMap.Data;
using NsccCourseMap.Models;

namespace NsccCourseMap_Neo.Pages.DiplomaPrograms
{
  public class IndexModel : PageModel
  {
    private readonly NsccCourseMap.Data.NsccCourseMapContext _context;

    public IndexModel(NsccCourseMap.Data.NsccCourseMapContext context)
    {
      _context = context;
    }

    public IList<DiplomaProgram> DiplomaProgram { get; set; }

    public async Task OnGetAsync()
    {
      IQueryable<DiplomaProgram> sortResult = from dp in _context.DiplomaPrograms
                                              select dp;

      sortResult = sortResult.OrderBy(dp => dp.Title);
      DiplomaProgram = await sortResult.AsNoTracking().ToListAsync();
    }
  }
}
