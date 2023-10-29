using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.DTOs
{
    public class UserDTO
    {
        public int UserId { get; set; }
        public string UserName { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string FullName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string? Avatar { get; set; }
        public string? Description { get; set; }
        public int RoleId { get; set; }
        public bool Status { get; set; }
    }
}
