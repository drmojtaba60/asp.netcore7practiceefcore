using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

using EfCorePractice.Persistence.Models;

namespace EfCorePractice.Persistence.Configurations
{
    internal sealed class StudentCourseConfiguration : IEntityTypeConfiguration<StudentCourse>, IMyEntityConfiguration
    {
        public void Configure(EntityTypeBuilder<StudentCourse> builder)
        {
            builder.ToTable(nameof(StudentCourse), "class");

            builder.HasKey(t =>new { t.StudentId,t.CourseId});

            //Relation Many to Many
            builder.HasOne(b => b.Student)
                .WithMany(s => s.StudentCourses)
                .HasForeignKey(b => b.StudentId);

            builder.HasOne(b => b.Course)
               .WithMany(s => s.StudentCourses)
               .HasForeignKey(b => b.CourseId);
            //Relation Many to Many
        }
    }
}
