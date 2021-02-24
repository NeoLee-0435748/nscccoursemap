using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

//Ref: https://docs.microsoft.com/en-us/aspnet/core/data/ef-rp/complex-data-model?view=aspnetcore-5.0&tabs=visual-studio
namespace NsccCourseMap.Models
{
  [Table("Courses")]
  public class Course
  {
    //Scalar properties
    public int Id { get; set; }
    [RegularExpression(@"^[A-Z]{4}[ ]\d{4}$")]
    [StringLength(9, MinimumLength = 9)]
    [Required(ErrorMessage = "Please enter course code")]
    [Display(Name = "Course Code")]
    public string CourseCode { get; set; }
    [StringLength(100, MinimumLength = 5)]
    [Required(ErrorMessage = "Please enter title")]
    public string Title { get; set; }

    //Navigation properties
    public virtual ICollection<CoursePrerequisite> Prerequisites { get; set; }
    public virtual ICollection<CoursePrerequisite> IsPrerequisiteFor { get; set; }
    public ICollection<CourseOffering> CourseOfferings { get; set; }
  }
}