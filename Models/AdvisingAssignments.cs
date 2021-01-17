using System;
using System.ComponentModel.DataAnnotations;

namespace RazorPagesMovie.Models
{
  //Scalar properties
  public class AdvisingAssignments
  {
    public int ID { get; set; }
    public int InstructorId { get; set; }
    public int DiplomaProgramYearSectionId { get; set; }

    //Navigation properties
    public Instructors Instructor { get; set; }
    public DiplomaProgramYearSections DiplomaProgramYearSection { get; set; }
  }
}