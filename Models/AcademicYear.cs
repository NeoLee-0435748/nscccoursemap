using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NsccCourseMap.Models
{
  [Table("AcademicYears")]
  public class AcademicYear
  {
    //Scalar properties
    public int Id { get; set; }
    [StringLength(20, MinimumLength = 5)]
    [Required(ErrorMessage = "Please enter title")]
    public string Title { get; set; }

    //Navigation properties
    public ICollection<Semester> Semesters { get; set; }
    public ICollection<DiplomaProgramYearSection> DiplomaProgramYearSections { get; set; }
  }
}