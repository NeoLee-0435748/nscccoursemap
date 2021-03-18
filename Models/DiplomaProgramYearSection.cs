using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace NsccCourseMap.Models
{
  [Table("DiplomaProgramYearSections")]
  public class DiplomaProgramYearSection
  {
    //Scalar properties
    public int Id { get; set; }
    [RegularExpression(@"^Section \d{1}$")]
    // [StringLength(9, MinimumLength = 9)]
    [Required(ErrorMessage = "Please enter title")]
    public string Title { get; set; }
    [Required]
    [Display(Name = "Diploma Program Year")]
    public int DiplomaProgramYearId { get; set; }
    [Required]
    [Display(Name = "Academic Year")]
    public int AcademicYearId { get; set; }

    //Navigation properties
    [Display(Name = "Diploma Program Year")]
    public DiplomaProgramYear DiplomaProgramYear { get; set; }
    public ICollection<CourseOffering> CourseOfferings { get; set; }
    [Display(Name = "Academic Year")]
    public AcademicYear AcademicYear { get; set; }
    public ICollection<AdvisingAssignment> AdvisingAssignments { get; set; }
  }
}