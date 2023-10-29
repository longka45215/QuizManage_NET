using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.DTOs
{
    public class QuizHistoryDTO
    {
        public int QuizId { get; set; }
        public int QuestionId { get; set; }
        public int UserAnswer { get; set; }
        public bool IsCorrect { get; set; }
    }
}
