using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NsccCourseMap.Models
{
  [Table("CourseOfferings")]
  public class CourseOffering
  {
    //Scalar properties
    public int Id { get; set; }
    public int? CourseId { get; set; }
    public int? InstructorId { get; set; }
    public int? DiplomaProgramYearSectionId { get; set; }
    public int? SemesterId { get; set; }
    [Required]
    [DefaultValue(false)]
    public bool IsDirectedElective { get; set; }

    //Navigation properties
    public Course Course { get; set; }
    public Instructor Instructor { get; set; }
    public DiplomaProgramYearSection DiplomaProgramYearSection { get; set; }
    public Semester Semester { get; set; }
  }
}