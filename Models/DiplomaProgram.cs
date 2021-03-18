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
    [MinLength(10, ErrorMessage = "Title cannot be less than 10")]
    [Required(ErrorMessage = "Please enter title")]
    public string Title { get; set; }

    //Navigation properties
    public ICollection<DiplomaProgramYear> DiplomaProgramYears { get; set; }
  }
}