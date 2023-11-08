using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

using EfCorePractice.Persistence.Models;

namespace EfCorePractice.Persistence.Configurations
{
    internal sealed class CourseConfiguration : IEntityTypeConfiguration<Course>, IMyEntityConfiguration
    {
        public void Configure(EntityTypeBuilder<Course> builder)
        {
            builder.ToTable(nameof(Course), "class");

            builder.Property(b=>b.Name).HasMaxLength(100).IsRequired();  
           
            
        }
    }

}
