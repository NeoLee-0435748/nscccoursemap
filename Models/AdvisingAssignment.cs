using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace NsccCourseMap.Models
{
  [Table("AdvisingAssignments")]
  [Index(nameof(InstructorId), nameof(DiplomaProgramYearSectionId))]
  public class AdvisingAssignment
  {
    //Scalar properties
    public int Id { get; set; }
    [Required]
    public int InstructorId { get; set; }
    [Required]
    public int DiplomaProgramYearSectionId { get; set; }

    //Navigation properties
    public Instructor Instructor { get; set; }
    public DiplomaProgramYearSection DiplomaProgramYearSection { get; set; }
  }
}