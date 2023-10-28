using System;
using System.Collections.Generic;

namespace BusinessObject.Models
{
    public partial class CourseCategory
    {
        public CourseCategory()
        {
            Courses = new HashSet<Course>();
        }

        public int CategoryId { get; set; }
        public string CategoryName { get; set; } = null!;

        public virtual ICollection<Course> Courses { get; set; }
    }
}
