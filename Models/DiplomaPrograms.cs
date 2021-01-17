using System;
using System.ComponentModel.DataAnnotations;

namespace NsccCourseMap.Models
{
  //Scalar properties
  public class DiplomaPrograms
  {
    public int ID { get; set; }
    [StringLength(100, MinimumLength = 1)]
    [Required]
    public string Title { get; set; }

    //Navigation properties
    public DiplomaProgramYears DiplomaProgramYears { get; set; }
  }
}