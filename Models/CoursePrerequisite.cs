using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

// Ref: https://stackoverflow.com/questions/54196199/entity-framework-core-multiple-one-to-many-relationships-between-two-entities
namespace NsccCourseMap.Models
{
  [Table("CoursePrerequisites")]
  public class CoursePrerequisite
  {
    //Scalar properties
    public int Id { get; set; }
    public int CourseId { get; set; }
    public int PrerequisiteId { get; set; }

    //Navigation properties
    [ForeignKey("CourseId")]
    public virtual Course Course { get; set; }
    [ForeignKey("PrerequisiteId")]
    public virtual Course Prerequisite { get; set; }
  }
}