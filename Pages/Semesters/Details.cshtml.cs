using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using NsccCourseMap.Data;
using NsccCourseMap.Models;

namespace NsccCourseMap_Neo.Pages.Semesters
{
  public class DetailsModel : PageModel
  {
    private readonly NsccCourseMap.Data.NsccCourseMapContext _context;

    public DetailsModel(NsccCourseMap.Data.NsccCourseMapContext context)
    {
      _context = context;
    }

    public Semester Semester { get; set; }

    public async Task<IActionResult> OnGetAsync(int? id)
    {
      if (id == null)
      {
        return NotFound();
      }

      Semester = await _context
        .Semesters
        .Include(s => s.AcademicYear)
        .Include(s => s.CourseOfferings)
        .ThenInclude(co => co.DiplomaProgramYearSection.DiplomaProgramYear.DiplomaProgram)
        .Include(s => s.CourseOfferings)
        .ThenInclude(co => co.Course)
        .FirstOrDefaultAsync(m => m.Id == id);

      if (Semester == null)
      {
        return NotFound();
      }

      return Page();
    }
  }
}
