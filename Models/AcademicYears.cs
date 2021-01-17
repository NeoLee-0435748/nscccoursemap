using System;
using System.ComponentModel.DataAnnotations;

namespace NsccCourseMap.Models
{
  //Scalar properties
  public class AcademicYears
  {
    public int ID { get; set; }
    [StringLength(50, MinimumLength = 3)]
    [Required]
    public string Title { get; set; }

    //Navigation properties
    public Semesters Semesters { get; set; }
    public DiplomaProgramYearSections DiplomaProgramYearSections { get; set; }
  }
}