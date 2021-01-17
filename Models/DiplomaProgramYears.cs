using System;
using System.ComponentModel.DataAnnotations;

namespace NsccCourseMap.Models
{
  //Scalar properties
  public class DiplomaProgramYears
  {
    public int ID { get; set; }
    [StringLength(100, MinimumLength = 1)]
    [Required]
    public string Title { get; set; }
    public int DiplomaProgramId { get; set; }

    //Navigation properties
    public DiplomaPrograms diplomaProgram { get; set; }
    public DiplomaProgramYearSections DiplomaProgramYearSections { get; set; }
  }
}