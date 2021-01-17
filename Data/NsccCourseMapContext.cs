using Microsoft.EntityFrameworkCore;

namespace NsccCourseMap.Data
{
  public class NsccCourseMapContext : DbContext
  {
    public NsccCourseMapContext(
        DbContextOptions<NsccCourseMapContext> options)
        : base(options)
    {
    }

    public DbSet<NsccCourseMap.Models.AcademicYears> AcademicYears { get; set; }
    public DbSet<NsccCourseMap.Models.AdvisingAssignments> AdvisingAssignments { get; set; }
    public DbSet<NsccCourseMap.Models.CourseOfferings> CourseOfferings { get; set; }
    public DbSet<NsccCourseMap.Models.CoursePrerequisites> CoursePrerequisites { get; set; }
    public DbSet<NsccCourseMap.Models.Courses> Courses { get; set; }
    public DbSet<NsccCourseMap.Models.DiplomaPrograms> DiplomaPrograms { get; set; }
    public DbSet<NsccCourseMap.Models.DiplomaProgramYearSections> DiplomaProgramYearSections { get; set; }
    public DbSet<NsccCourseMap.Models.Instructors> Instructors { get; set; }
    public DbSet<NsccCourseMap.Models.Semesters> Semesters { get; set; }
  }
}