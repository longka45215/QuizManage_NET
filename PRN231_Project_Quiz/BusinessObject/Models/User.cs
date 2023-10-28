using System;
using System.Collections.Generic;

namespace BusinessObject.Models
{
    public partial class User
    {
        public User()
        {
            Quizzes = new HashSet<Quiz>();
        }

        public int UserId { get; set; }
        public string UserName { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string FullName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string? Avatar { get; set; }
        public string? Description { get; set; }
        public int RoleId { get; set; }
        public bool Status { get; set; }
        public DateTime RegisterDay { get; set; }

        public virtual RoleName Role { get; set; } = null!;
        public virtual ICollection<Quiz> Quizzes { get; set; }
    }
}
