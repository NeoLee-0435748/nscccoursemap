using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NsccCourseMap.Models
{
  [Table("Semesters")]
  public class Semester
  {
    //Scalar properties
    public int Id { get; set; }
    [StringLength(50, MinimumLength = 3)]
    [Required]
    public string Name { get; set; }
    [Column(TypeName = "Date")]
    [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
    [Required]
    public DateTime StartDate { get; set; }
    [Column(TypeName = "Date")]
    [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
    [Required]
    public DateTime EndDate { get; set; }
    [Required]
    public int AcademicYearId { get; set; }

    //Navigation properties
    public AcademicYear AcademicYear { get; set; }
    public ICollection<CourseOffering> CourseOfferings { get; set; }
  }
}