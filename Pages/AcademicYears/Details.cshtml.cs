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
  public class DetailsModel : PageModel
  {
    private readonly NsccCourseMap.Data.NsccCourseMapContext _context;

    public DetailsModel(NsccCourseMap.Data.NsccCourseMapContext context)
    {
      _context = context;
    }

    public AcademicYear AcademicYear { get; set; }

    public async Task<IActionResult> OnGetAsync(int? id)
    {
      if (id == null)
      {
        return NotFound();
      }

      AcademicYear = await _context
      .AcademicYears
      .Include(ay => ay.Semesters.OrderBy(s => s.StartDate))
      .Include(ay => ay.DiplomaProgramYearSections)
      .ThenInclude(dpys => dpys.DiplomaProgramYear.DiplomaProgram)
      .Include(ay => ay.DiplomaProgramYearSections)
      .ThenInclude(dpys => dpys.AdvisingAssignments)
      .ThenInclude(aa => aa.Instructor)
      .FirstOrDefaultAsync(m => m.Id == id);

      if (AcademicYear == null)
      {
        return NotFound();
      }
      return Page();
    }
  }
}
