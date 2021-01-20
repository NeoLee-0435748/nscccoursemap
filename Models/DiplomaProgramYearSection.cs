using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NsccCourseMap.Models
{
  [Table("DiplomaProgramYearSections")]
  public class DiplomaProgramYearSection
  {
    //Scalar properties
    public int Id { get; set; }
    [StringLength(100, MinimumLength = 1)]
    [Required]
    public string Title { get; set; }
    [Required]
    public int DiplomaProgramYearId { get; set; }
    [Required]
    public int AcademicYearId { get; set; }

    //Navigation properties
    public DiplomaProgramYear DiplomaProgramYear { get; set; }
    public ICollection<CourseOffering> CourseOfferings { get; set; }
    public AcademicYear AcademicYear { get; set; }
    public ICollection<AdvisingAssignment> AdvisingAssignments { get; set; }
  }
}