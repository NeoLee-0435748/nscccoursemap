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
  public class DetailsModel : PageModel
  {
    private readonly NsccCourseMap.Data.NsccCourseMapContext _context;

    public DetailsModel(NsccCourseMap.Data.NsccCourseMapContext context)
    {
      _context = context;
    }

    public CourseOffering CourseOffering { get; set; }

    public async Task<IActionResult> OnGetAsync(int? id)
    {
      if (id == null)
      {
        return NotFound();
      }

      CourseOffering = await _context.CourseOfferings
          .Include(c => c.Course)
          .Include(c => c.DiplomaProgramYearSection)
          .ThenInclude(dpys => dpys.DiplomaProgramYear.DiplomaProgram)
          .Include(c => c.Instructor)
          .Include(c => c.Semester)
          .FirstOrDefaultAsync(m => m.Id == id);

      if (CourseOffering == null)
      {
        return NotFound();
      }
      return Page();
    }
  }
}
