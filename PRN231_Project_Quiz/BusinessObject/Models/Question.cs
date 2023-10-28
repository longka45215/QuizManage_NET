using System;
using System.Collections.Generic;

namespace BusinessObject.Models
{
    public partial class Question
    {
        public Question()
        {
            Answers = new HashSet<Answer>();
        }

        public int QuestionId { get; set; }
        public string SubjectId { get; set; } = null!;
        public string Content { get; set; } = null!;
        public string? Explain { get; set; }

        public virtual Subject Subject { get; set; } = null!;
        public virtual ICollection<Answer> Answers { get; set; }
    }
}
