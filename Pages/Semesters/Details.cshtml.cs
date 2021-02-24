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
  public class NewCourseOfferingData
  {
    public string DiplomaProgramTitle { get; set; }
    public string DiplomaProgramYearTitle { get; set; }
    public string CourseCode { get; set; }
    public string CourseTitle { get; set; }
    public string InstructorName { get; set; }
    public string DirectedElective { get; set; }
  }

  public class DetailsModel : PageModel
  {
    private readonly NsccCourseMap.Data.NsccCourseMapContext _context;

    public DetailsModel(NsccCourseMap.Data.NsccCourseMapContext context)
    {
      _context = context;
    }

    public Semester Semester { get; set; }

    public List<NewCourseOfferingData> NewCourseOfferingData { get; set; }

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
        .Include(s => s.CourseOfferings)
        .ThenInclude(co => co.Instructor)
        .FirstOrDefaultAsync(m => m.Id == id);

      if (Semester == null)
      {
        return NotFound();
      }

      NewCourseOfferingData = Semester.CourseOfferings
        .Select(co => new NewCourseOfferingData()
        {
          DiplomaProgramTitle = co.DiplomaProgramYearSection.DiplomaProgramYear.DiplomaProgram.Title,
          DiplomaProgramYearTitle = co.DiplomaProgramYearSection.DiplomaProgramYear.Title,
          CourseCode = co.Course.CourseCode,
          CourseTitle = co.Course.Title,
          InstructorName = co.Instructor.FirstName + " " + co.Instructor.LastName,
          DirectedElective = co.IsDirectedElective == true ? "Directed Elective" : ""
        })
        .OrderBy(nco => nco.DiplomaProgramTitle)
        .ThenBy(nco => nco.DiplomaProgramYearTitle)
        .ThenBy(nco => nco.CourseCode)
        .ToList();

      return Page();
    }
  }
}
