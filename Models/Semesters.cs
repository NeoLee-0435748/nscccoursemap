using System;
using System.ComponentModel.DataAnnotations;

namespace NsccCourseMap.Models
{
  //Scalar properties
  public class Semesters
  {
    public int ID { get; set; }
    [StringLength(50, MinimumLength = 3)]
    [Required]
    public string Name { get; set; }
    [DataType(DataType.Date)]
    [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
    [Required]
    public DateTime StartDate { get; set; }
    [DataType(DataType.Date)]
    [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
    [Required]
    public DateTime EndDate { get; set; }
    public int AcademicYearId { get; set; }

    //Navigation properties
    public AcademicYears AcademicYear { get; set; }
    public CourseOfferings CourseOfferings { get; set; }
  }
}