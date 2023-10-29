using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.DTOs
{
    public class SubjectDTO
    {
        public string SubjectId { get; set; } = null!;
        public string SubjectName { get; set; } = null!;
        public string? Description { get; set; }
        public string CourseId { get; set; } = null!;
    }
}
