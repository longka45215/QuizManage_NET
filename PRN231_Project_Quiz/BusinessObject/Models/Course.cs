using System;
using System.Collections.Generic;

namespace BusinessObject.Models
{
    public partial class Course
    {
        public Course()
        {
            Subjects = new HashSet<Subject>();
        }

        public string CourseId { get; set; } = null!;
        public string CourseName { get; set; } = null!;
        public string? Description { get; set; }
        public int CategoryId { get; set; }
        public string? Thumbnail { get; set; }

        public virtual CourseCategory Category { get; set; } = null!;
        public virtual ICollection<Subject> Subjects { get; set; }
    }
}
