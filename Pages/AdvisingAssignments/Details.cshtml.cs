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
  public class DetailsModel : PageModel
  {
    private readonly NsccCourseMap.Data.NsccCourseMapContext _context;

    public DetailsModel(NsccCourseMap.Data.NsccCourseMapContext context)
    {
      _context = context;
    }

    public AdvisingAssignment AdvisingAssignment { get; set; }

    public async Task<IActionResult> OnGetAsync(int? id)
    {
      if (id == null)
      {
        return NotFound();
      }

      AdvisingAssignment = await _context.AdvisingAssignments
          .Include(a => a.Instructor)
          .Include(a => a.DiplomaProgramYearSection)
          .ThenInclude(dpys => dpys.DiplomaProgramYear.DiplomaProgram)
          .FirstOrDefaultAsync(m => m.Id == id);

      if (AdvisingAssignment == null)
      {
        return NotFound();
      }
      return Page();
    }
  }
}
