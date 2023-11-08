using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

using EfCorePractice.Persistence.Models;

namespace EfCorePractice.Persistence.Configurations
{
    internal sealed class ClassRoomConfiguration : IEntityTypeConfiguration<ClassRoom>, IMyEntityConfiguration
    {
        public void Configure(EntityTypeBuilder<ClassRoom> builder)
        {
            builder.ToTable(nameof(ClassRoom), "class");
            //builder.Property(b=>b.Name).HasMaxLength(100).IsRequired();
            builder.Property("Name").HasMaxLength(100).IsRequired();

            builder.HasMany(b => b.Students)
                .WithOne(b => b.ClassRoom)
                .HasForeignKey(b => b.ClassRoomId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
