using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace NsccCourseMap.Models
{
  [Table("DiplomaProgramYears")]
  [Index(nameof(Title), nameof(DiplomaProgramId))]
  public class DiplomaProgramYear
  {
    //Scalar properties
    public int Id { get; set; }
    [RegularExpression(@"^Year [1-4]$")]
    [StringLength(100, MinimumLength = 1)]
    [Required(ErrorMessage = "Please enter title")]
    public string Title { get; set; }
    [Required]
    public int DiplomaProgramId { get; set; }

    //Navigation properties
    public DiplomaProgram DiplomaProgram { get; set; }
    public ICollection<DiplomaProgramYearSection> DiplomaProgramYearSections { get; set; }
  }
}