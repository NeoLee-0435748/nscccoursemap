using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace NsccCourseMap.Models
{
  [Table("AdvisingAssignments")]
  public class AdvisingAssignment
  {
    //Scalar properties
    public int Id { get; set; }
    [Required]
    [Display(Name = "Instructor")]
    public int InstructorId { get; set; }
    [Required]
    [Display(Name = "Diploma Program Year Section")]
    public int DiplomaProgramYearSectionId { get; set; }

    //Navigation properties
    public Instructor Instructor { get; set; }
    [Display(Name = "Diploma Program Year Section")]
    public DiplomaProgramYearSection DiplomaProgramYearSection { get; set; }
  }
}