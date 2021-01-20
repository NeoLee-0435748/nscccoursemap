using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NsccCourseMap.Models
{
  [Table("DiplomaPrograms")]
  public class DiplomaProgram
  {
    //Scalar properties
    public int Id { get; set; }
    [StringLength(100, MinimumLength = 1)]
    [Required]
    public string Title { get; set; }

    //Navigation properties
    public ICollection<DiplomaProgramYear> DiplomaProgramYears { get; set; }
  }
}