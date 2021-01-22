using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NsccCourseMap.Models
{
  [Table("Instructors")]
  public class Instructor
  {
    //Scalar properties
    public int Id { get; set; }
    // [StringLength(50, MinimumLength = 3)]
    [Required(ErrorMessage = "Please enter first name")]
    public string FirstName { get; set; }
    // [StringLength(50, MinimumLength = 3)]
    [Required(ErrorMessage = "Please enter last name")]
    public string LastName { get; set; }

    //Navigation properties
    public ICollection<CourseOffering> CourseOfferings { get; set; }
    public ICollection<AdvisingAssignment> AdvisingAssignments { get; set; }
  }
}