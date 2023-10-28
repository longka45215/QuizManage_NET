using System;
using System.Collections.Generic;

namespace BusinessObject.Models
{
    public partial class QuizHistory
    {
        public int QuizId { get; set; }
        public int QuestionId { get; set; }
        public int UserAnswer { get; set; }
        public bool IsCorrect { get; set; }

        public virtual Question Question { get; set; } = null!;
        public virtual Quiz Quiz { get; set; } = null!;
    }
}
