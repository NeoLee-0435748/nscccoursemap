using System;
using System.ComponentModel.DataAnnotations;

namespace NsccCourseMap.Models
{
  //Scalar properties
  public class Courses
  {
    public int ID { get; set; }
    [StringLength(20, MinimumLength = 8)]
    [Required]
    public string CourseCode { get; set; }
    [StringLength(100, MinimumLength = 1)]
    [Required]
    public string Title { get; set; }

    //Navigation properties
    public CoursePrerequisites Prerequisites { get; set; }
    public CoursePrerequisites IsPrerequiseteFor { get; set; }
    public CourseOfferings CourseOfferings { get; set; }
  }
}