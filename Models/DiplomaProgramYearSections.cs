using System;
using System.ComponentModel.DataAnnotations;

namespace NsccCourseMap.Models
{
  //Scalar properties
  public class DiplomaProgramYearSections
  {
    public int ID { get; set; }
    [StringLength(100, MinimumLength = 1)]
    [Required]
    public string Title { get; set; }
    public int DiplomaProgramYearId { get; set; }
    public int AcademicYearId { get; set; }

    //Navigation properties
    public DiplomaProgramYears diplomaProgramYear { get; set; }
    public CourseOfferings CourseOfferings { get; set; }
    public AcademicYears AcademicYear { get; set; }
    public AdvisingAssignments AdvisingAssignments { get; set; }
  }
}