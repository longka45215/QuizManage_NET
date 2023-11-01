using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.DTOs
{
    public class AnswerDTO
    {
        [Key]
        public int AnswerId { get; set; }
        public int QuestionId { get; set; }
        public string Content { get; set; } = null!;
        public bool? IsAnswer { get; set; }
    }
}
