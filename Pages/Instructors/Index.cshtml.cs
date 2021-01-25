using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using NsccCourseMap.Data;
using NsccCourseMap.Models;

namespace NsccCourseMap_Neo.Pages.Instructors
{
  public class IndexModel : PageModel
  {
    private readonly NsccCourseMap.Data.NsccCourseMapContext _context;

    public IndexModel(NsccCourseMap.Data.NsccCourseMapContext context)
    {
      _context = context;
    }

    public IList<Instructor> Instructor { get; set; }

    public async Task OnGetAsync()
    {
      IQueryable<Instructor> sortResult = from i in _context.Instructors
                                          select i;

      sortResult = sortResult.OrderBy(i => i.LastName);
      Instructor = await sortResult.AsNoTracking().ToListAsync();
    }
  }
}
