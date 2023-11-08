using EfCorePractice.Persistence.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EfCorePractice.Persistence.Models
{
    public record Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Mobile { get; set; }
        public string NationalId { get; set; }
        public DateTime? BrithDate { get; set; }
        public StudentStatus Status { get; set; }

        public int ClassRoomId { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public int? DeletedBy { get; set; }
        public DateTime? DeletedDate { get; set; }

        public ClassRoom ClassRoom { get; set; }
        public ICollection<StudentCourse>   StudentCourses { get; set; }

    }
}
