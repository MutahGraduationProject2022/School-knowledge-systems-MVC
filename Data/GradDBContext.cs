using Microsoft.EntityFrameworkCore;
using SKC_MVC.Models;

namespace SKC_MVC.Data
{
    public class GradDBContext : DbContext
    {
        public GradDBContext(DbContextOptions<GradDBContext> options) : base(options)
        {
        }

        public DbSet<Class> Classes { get; set; }
        public DbSet<Section> Sections { get; set; }
        public DbSet<ClSeSu> ClSeSus { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Grades> Grades { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Section>()
            .HasOne(s => s.Class)
            .WithMany(c => c.Sections)
            .HasForeignKey(s => s.ClassId);

            modelBuilder.Entity<ClSeSu>()
                .HasOne(c => c.Class)
                .WithMany(cl => cl.ClSeSu)
                .HasForeignKey(c => c.ClassId);

            modelBuilder.Entity<Grades>()
                .HasOne(g => g.Student)
                .WithMany(s => s.Grades)
                .HasForeignKey(g => g.StudentId);

            modelBuilder.Entity<Class>().HasData(
               new Class
               {
                   Id = 1,
                   NumberOfClassesPerWeek = 5,
                   NumberOfStudents = 30,
               }
           );

            modelBuilder.Entity<Section>().HasData(
                new Section
                {
                    Id = 1,
                    Count = 25,
                    ClassId = 1,
                }
            );

            modelBuilder.Entity<ClSeSu>().HasData(
                new ClSeSu
                {
                    Id = 1,
                    Flag = true,
                    NumOfClassPerWeek = 4,
                    ClassId = 1,
                }
            );

            modelBuilder.Entity<Student>().HasData(
                new Student
                {
                    Id = 1,
                    Name = "John Doe",
                    Class = "Some Class",
                    Section = "A",
                }
            );

            modelBuilder.Entity<Grades>().HasData(
                new Grades
                {
                    Id = 1,
                    Homeworks = 95,
                    FinalExam = 85,
                    TotalGrades = 90,
                    Exam1 = 88,
                    Exam2 = 92,
                    StudentId = 1,
                }
            );
        }
    }
}