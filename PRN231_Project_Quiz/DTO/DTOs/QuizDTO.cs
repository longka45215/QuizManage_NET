using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.DTOs
{
    public class QuizDTO
    {
        public int QuizId { get; set; }
        public string SubjectId { get; set; } = null!;
        public int UserId { get; set; }
        public string TimeStart { get; set; } = null!;
        public double Score { get; set; }
    }
}
