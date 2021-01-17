using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace RazorPagesMovie.Models
{
  //Scalar properties
  public class CourseOfferings
  {
    public int ID { get; set; }
    public int CourseId { get; set; }
    public int InstructorId { get; set; }
    public int DiplomaProgramYearSectionId { get; set; }
    public int SemesterId { get; set; }
    [DefaultValue(false)]
    public bool IsDirectedElective { get; set; }

    //Navigation properties
    public DiplomaProgramYearSections diplomaProgramYearSection { get; set; }
    public Semesters Semester { get; set; }
    public Courses Course { get; set; }
    public Instructors Instructor { get; set; }
  }
}