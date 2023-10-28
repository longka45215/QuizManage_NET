using System;
using System.Collections.Generic;

namespace BusinessObject.Models
{
    public partial class Answer
    {
        public int AnswerId { get; set; }
        public int QuestionId { get; set; }
        public string Content { get; set; } = null!;
        public bool? IsAnswer { get; set; }

        public virtual Question Question { get; set; } = null!;
    }
}
