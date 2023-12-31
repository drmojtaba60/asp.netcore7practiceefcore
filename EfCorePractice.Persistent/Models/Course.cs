﻿namespace EfCorePractice.Persistence.Models
{
    public record Course
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public int CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public int? DeletedBy { get; set; }
        public DateTime? DeletedDate { get; set; }
        public ICollection<StudentCourse> StudentCourses { get; set; }
    }
}
