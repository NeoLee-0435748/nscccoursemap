using System;
using System.ComponentModel.DataAnnotations;

namespace RazorPagesMovie.Models
{
  //Scalar properties
  public class CoursePrerequisites
  {
    public int ID { get; set; }
    public int CourseId { get; set; }
    public int PrerequisiteID { get; set; }

    //Navigation properties
    public Courses Course { get; set; }
    public Courses Prerequisite { get; set; }
  }
}