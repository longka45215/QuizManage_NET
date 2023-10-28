using System;
using System.Collections.Generic;

namespace BusinessObject.Models
{
    public partial class Subject
    {
        public Subject()
        {
            Questions = new HashSet<Question>();
            Quizzes = new HashSet<Quiz>();
        }

        public string SubjectId { get; set; } = null!;
        public string SubjectName { get; set; } = null!;
        public string? Description { get; set; }
        public string CourseId { get; set; } = null!;

        public virtual Course Course { get; set; } = null!;
        public virtual ICollection<Question> Questions { get; set; }
        public virtual ICollection<Quiz> Quizzes { get; set; }
    }
}
