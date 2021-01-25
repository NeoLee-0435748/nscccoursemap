using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NsccCourseMap.Models
{
  [Table("Semesters")]
  public class Semester
  {
    //Scalar properties
    public int Id { get; set; }
    [StringLength(50, MinimumLength = 3)]
    [Required(ErrorMessage = "Please enter name")]
    public string Name { get; set; }
    [Column(TypeName = "Date")]
    [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
    [Required(ErrorMessage = "Please enter start date")]
    [Display(Name = "Start Date")]
    public DateTime StartDate { get; set; }
    [CompareTwoDates("StartDate")]
    [Column(TypeName = "Date")]
    [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
    [Required(ErrorMessage = "Please enter end date")]
    [Display(Name = "End Date")]
    public DateTime EndDate { get; set; }
    [Required]
    public int AcademicYearId { get; set; }

    //Navigation properties
    [Display(Name = "Academic Year")]
    public AcademicYear AcademicYear { get; set; }
    public ICollection<CourseOffering> CourseOfferings { get; set; }
  }
}