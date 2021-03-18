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
  public class NewCourseOfferingData
  {
    public string DiplomaProgramYearSectionTitle { get; set; }
    public string SemesterName { get; set; }
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

    public DiplomaProgramYear DiplomaProgramYear { get; set; }

    public List<NewCourseOfferingData> NewCourseOfferingData { get; set; }

    public async Task<IActionResult> OnGetAsync(int? id)
    {
      if (id == null)
      {
        return NotFound();
      }

      DiplomaProgramYear = await _context.DiplomaProgramYears
        .Include(d => d.DiplomaProgram)
        .Include(d => d.DiplomaProgramYearSections)
          .ThenInclude(dpys => dpys.CourseOfferings)
          .ThenInclude(co => co.Semester)
        .Include(d => d.DiplomaProgramYearSections)
          .ThenInclude(dpys => dpys.CourseOfferings)
          .ThenInclude(co => co.Course)
        .Include(d => d.DiplomaProgramYearSections)
          .ThenInclude(dpys => dpys.CourseOfferings)
          .ThenInclude(co => co.Instructor)
        .FirstOrDefaultAsync(m => m.Id == id);

      if (DiplomaProgramYear == null)
      {
        return NotFound();
      }

      NewCourseOfferingData = new List<NewCourseOfferingData>();

      foreach (var dpys in DiplomaProgramYear.DiplomaProgramYearSections)
      {
        if (dpys.CourseOfferings.Count > 0)
        {
          List<NewCourseOfferingData> tempNewCourseOfferingData;

          tempNewCourseOfferingData = dpys.CourseOfferings
              .OrderByDescending(co => co.Semester.StartDate)
              .ThenBy(co => co.DiplomaProgramYearSection.DiplomaProgramYear.DiplomaProgram.Title)
              .ThenBy(co => co.Course.CourseCode)
              .Select(co => new NewCourseOfferingData()
              {
                DiplomaProgramYearSectionTitle = dpys.Title,
                SemesterName = co.Semester.Name,
                CourseCode = co.Course.CourseCode,
                CourseTitle = co.Course.Title,
                InstructorName = co.Instructor.FirstName + " " + co.Instructor.LastName,
                DirectedElective = co.IsDirectedElective == true ? "Directed Elective" : ""
              })
              .ToList();

          foreach (var tncod in tempNewCourseOfferingData)
          {
            NewCourseOfferingData.Add(tncod);
          }
        }
      }

      NewCourseOfferingData = NewCourseOfferingData.OrderBy(ncod => ncod.DiplomaProgramYearSectionTitle).ToList();

      return Page();
    }
  }
}
