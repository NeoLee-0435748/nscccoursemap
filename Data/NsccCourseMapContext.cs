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

      //define combine unique columns
      modelBuilder.Entity<DiplomaProgramYear>()
        .HasIndex(dpy => new { dpy.Title, dpy.DiplomaProgramId })
        .IsUnique(true);

      modelBuilder.Entity<DiplomaProgramYearSection>()
        .HasIndex(dpys => new { dpys.Title, dpys.DiplomaProgramYearId, dpys.AcademicYearId })
        .IsUnique(true);

      modelBuilder.Entity<AdvisingAssignment>()
        .HasIndex(aa => new { aa.InstructorId, aa.DiplomaProgramYearSectionId })
        .IsUnique(true);

      modelBuilder.Entity<CourseOffering>()
        .HasIndex(co => new { co.CourseId, co.InstructorId, co.DiplomaProgramYearSectionId, co.SemesterId })
        .IsUnique(true);

      modelBuilder.Entity<CoursePrerequisite>()
        .HasIndex(cp => new { cp.CourseId, cp.PrerequisiteId })
        .IsUnique(true);

      // RECONCILE THE MANY TO MANY RECURSIVE (VERSION 1)
      modelBuilder.Entity<Course>()
          .HasMany(c => c.Prerequisites)
          .WithOne(cpr => cpr.Course)
          .HasForeignKey(cpr => cpr.CourseId);
      modelBuilder.Entity<Course>()
          .HasMany(c => c.IsPrerequisiteFor)
          .WithOne(cpr => cpr.Prerequisite)
          .HasForeignKey(cpr => cpr.PrerequisiteId);

      // RECONCILE THE MANY TO MANY RECURSIVE (VERSION 2)
      // modelBuilder.Entity<Course>()
      // .HasMany(c => c.Prerequisites)
      // .WithMany(c => c.IsPrerequisiteFor);

      // TURN OFF CASCADE DELETE FOR ALL RELATIONSHIPS
      foreach (var entity in modelBuilder.Model.GetEntityTypes())
      {
        foreach (var fk in entity.GetForeignKeys())
        {
          fk.DeleteBehavior = DeleteBehavior.NoAction;
        }
      }
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