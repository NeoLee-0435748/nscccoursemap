using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NsccCourseMap.Models
{
  [Table("Courses")]
  public class Course
  {
    //Scalar properties
    public int Id { get; set; }
    [StringLength(20, MinimumLength = 8)]
    [Required]
    public string CourseCode { get; set; }
    [StringLength(100, MinimumLength = 1)]
    [Required]
    public string Title { get; set; }

    //Navigation properties
    [InverseProperty("Course")]
    public virtual ICollection<CoursePrerequisite> Prerequisites { get; set; }
    [InverseProperty("Prerequisite")]
    public virtual ICollection<CoursePrerequisite> IsPrerequisiteFor { get; set; }
    public ICollection<CourseOffering> CourseOfferings { get; set; }
  }
}