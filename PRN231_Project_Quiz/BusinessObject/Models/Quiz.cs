using System;
using System.Collections.Generic;

namespace BusinessObject.Models
{
    public partial class Quiz
    {
        public int QuizId { get; set; }
        public string SubjectId { get; set; } = null!;
        public int UserId { get; set; }
        public string TimeStart { get; set; } = null!;
        public double Score { get; set; }

        public virtual Subject Subject { get; set; } = null!;
        public virtual User User { get; set; } = null!;
    }
}
