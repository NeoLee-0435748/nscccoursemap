using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using NsccCourseMap.Data;
using NsccCourseMap.Models;

namespace NsccCourseMap_Neo.Pages.Courses
{
  public class DetailsModel : PageModel
  {
    private readonly NsccCourseMap.Data.NsccCourseMapContext _context;

    public DetailsModel(NsccCourseMap.Data.NsccCourseMapContext context)
    {
      _context = context;
    }

    public Course Course { get; set; }
    // public CoursePrerequisite CoursePrerequisites { get; set; }

    public async Task<IActionResult> OnGetAsync(int? id)
    {
      if (id == null)
      {
        return NotFound();
      }

      Course = await _context
      .Courses
      .Include(c => c.Prerequisites)
      .ThenInclude(p => p.Prerequisite)
      .FirstOrDefaultAsync(m => m.Id == id);

      if (Course == null)
      {
        return NotFound();
      }
      return Page();
    }
  }
}
