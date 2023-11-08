using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

using EfCorePractice.Persistence.Models;

namespace EfCorePractice.Persistence.Configurations
{
    internal sealed class StudentConfiguration: IEntityTypeConfiguration<Student>, IMyEntityConfiguration
    {
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            builder.ToTable(nameof(Student), "class");

            builder.Property(b => b.Name).HasColumnType("varchar").HasMaxLength(225);
            builder.Property(b => b.Email).HasMaxLength(100).HasColumnType("varchar");//using Microsoft.EntityFrameworkCore.SqlServer
            builder.Property(b => b.BrithDate).HasColumnType("datetime");
            builder.Property(b=>b.Mobile).HasColumnType("varchar").HasMaxLength(13);
            builder.Property(b=>b.FirstName).HasMaxLength(20);
            builder.Property(b => b.LastName).HasMaxLength(30);
            builder.Property(b => b.NationalId).HasColumnType("char").IsFixedLength().HasMaxLength(10);
        }
    }

    
}
