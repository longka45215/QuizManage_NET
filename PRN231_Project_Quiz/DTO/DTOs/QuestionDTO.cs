using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.DTOs
{
    public class QuestionDTO
    {
        [Key]
        public int QuestionId { get; set; }
        public string SubjectId { get; set; } = null!;
        public string Content { get; set; } = null!;
        public string? Explain { get; set; }
    }
}
