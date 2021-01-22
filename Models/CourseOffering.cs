using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace NsccCourseMap.Models
{
  [Table("CourseOfferings")]
  public class CourseOffering
  {
    //Scalar properties
    public int Id { get; set; }
    [Required]
    public int CourseId { get; set; }
    [Required]
    public int InstructorId { get; set; }
    [Required]
    public int DiplomaProgramYearSectionId { get; set; }
    [Required]
    public int SemesterId { get; set; }
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