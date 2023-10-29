using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.DTOs
{
    public class AnswerDTO
    {
        public int AnswerId { get; set; }
        public int QuestionId { get; set; }
        public string Content { get; set; } = null!;
        public bool? IsAnswer { get; set; }
    }
}
