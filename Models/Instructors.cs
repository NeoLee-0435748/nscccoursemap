using System;
using System.ComponentModel.DataAnnotations;

namespace NsccCourseMap.Models
{
  //Scalar properties
  public class Instructors
  {
    public int ID { get; set; }
    [StringLength(50, MinimumLength = 3)]
    [Required]
    public string FirstName { get; set; }
    [StringLength(50, MinimumLength = 3)]
    [Required]
    public string LastName { get; set; }

    //Navigation properties
    public CourseOfferings CourseOfferings { get; set; }
    public AdvisingAssignments AdvisingAssignments { get; set; }
  }
}