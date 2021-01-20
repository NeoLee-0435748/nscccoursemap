using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NsccCourseMap.Models
{
  [Table("DiplomaProgramYears")]
  public class DiplomaProgramYear
  {
    //Scalar properties
    public int Id { get; set; }
    [StringLength(100, MinimumLength = 1)]
    [Required]
    public string Title { get; set; }
    [Required]
    public int DiplomaProgramId { get; set; }

    //Navigation properties
    public DiplomaProgram DiplomaProgram { get; set; }
    public ICollection<DiplomaProgramYearSection> DiplomaProgramYearSections { get; set; }
  }
}