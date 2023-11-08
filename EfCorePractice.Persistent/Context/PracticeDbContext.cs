using EfCorePractice.Persistence.Configurations;
using EfCorePractice.Persistence.Models;
using Microsoft.EntityFrameworkCore;

namespace EfCorePractice.Persistence
{
    public class PracticeDbContext : DbContext
    {
        public PracticeDbContext(DbContextOptions options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            
            setDbSetes(modelBuilder);

            myConfiguraionOnEntitiesByReflectionMethod(modelBuilder);
            
        }
        public DbSet<Student> Students { get; set; }
        //public DbSet<ClassRoom> ClassRooms { get; set;}
        //public DbSet<Course> Courses { get; set; }
        //public DbSet<StudentCourse> StudentCourses { get; set; }

        /// <summary>
        /// using instead of DbSet Entities
        /// </summary>
        /// <param name="modelBuilder"></param>
        private void setDbSetes(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity(typeof(Student));
            //modelBuilder.Entity(typeof(ClassRoom));
            modelBuilder.Entity(typeof(Course));
            modelBuilder.Entity(typeof(StudentCourse));
        }
        //Grouping configuration
        private void myConfiguraionOnEntitiesNormalClassicMethod(ModelBuilder b)
        {
            b.ApplyConfiguration(new StudentConfiguration());
            b.ApplyConfiguration(new CourseConfiguration());
            b.ApplyConfiguration(new ClassRoomConfiguration());
            b.ApplyConfiguration(new StudentCourseConfiguration());
        }
        //It is possible to apply all configuration specified in types implementing IEntityTypeConfiguration in a given assembly.
        private void myConfiguraionOnEntitiesByReflectionMethod(ModelBuilder b)
        {
            b.ApplyConfigurationsFromAssembly(typeof(IMyEntityConfiguration).Assembly);
        }
    }


    //public class PracticeDbByModelBuilderEntityContext : DbContext
    //{
    //    public PracticeDbByModelBuilderEntityContext(DbContextOptions options) : base(options)
    //    {
    //    }
        //public DbSet<Student> Students { get; set; }
        //public DbSet<ClassRoom> ClassRooms { get; set; }
        //public DbSet<Course> Courses { get; set; }
        //public DbSet<StudentCourse> StudentCourses { get; set; }
    //    protected override void OnModelCreating(ModelBuilder modelBuilder)
    //    {
    //        base.OnModelCreating(modelBuilder);
    //        //using modelBuilder.Entity inseated of DbSet<Student>
    //        modelBuilder.Entity(typeof(Student));
    //        modelBuilder.Entity(typeof(ClassRoom));
    //        modelBuilder.Entity(typeof(Course));
    //        modelBuilder.Entity(typeof(StudentCourse));
    //        //using modelBuilder.Entity inseated of DbSet<Student>

    //    }

    //}
}
