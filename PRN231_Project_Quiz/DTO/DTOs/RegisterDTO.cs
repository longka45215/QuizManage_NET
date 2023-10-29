using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.DTOs
{
    public class RegisterDTO
    {
        public int UserId { get; set; }
        public string CourseId { get; set; } = null!;
    }
}
