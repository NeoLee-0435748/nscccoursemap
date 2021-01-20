using Microsoft.EntityFrameworkCore;
using NsccCourseMap.Models;

namespace NsccCourseMap.Data
{
  public class NsccCourseMapContext : DbContext
  {
    public NsccCourseMapContext(
        DbContextOptions<NsccCourseMapContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      //define unique columns
      modelBuilder.Entity<AcademicYear>()
        .HasAlternateKey(ay => ay.Title)
        .HasName("AlternateKey_AcademicYear_Title");

      modelBuilder.Entity<Course>()
        .HasAlternateKey(c => c.CourseCode)
        .HasName("AlternateKey_Course_CourseCode");

      modelBuilder.Entity<DiplomaProgram>()
        .HasAlternateKey(dp => dp.Title)
        .HasName("AlternateKey_DiplomaProgram_Title");

      modelBuilder.Entity<Semester>()
        .HasAlternateKey(s => s.Name)
        .HasName("AlternateKey_Semester_Name");
    }

    public DbSet<AcademicYear> AcademicYears { get; set; }
    public DbSet<AdvisingAssignment> AdvisingAssignments { get; set; }
    public DbSet<CourseOffering> CourseOfferings { get; set; }
    public DbSet<CoursePrerequisite> CoursePrerequisites { get; set; }
    public DbSet<Course> Courses { get; set; }
    public DbSet<DiplomaProgram> DiplomaPrograms { get; set; }
    public DbSet<DiplomaProgramYear> DiplomaProgramYears { get; set; }
    public DbSet<DiplomaProgramYearSection> DiplomaProgramYearSections { get; set; }
    public DbSet<Instructor> Instructors { get; set; }
    public DbSet<Semester> Semesters { get; set; }
  }
}