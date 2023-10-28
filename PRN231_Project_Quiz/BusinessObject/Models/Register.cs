using System;
using System.Collections.Generic;

namespace BusinessObject.Models
{
    public partial class Register
    {
        public int UserId { get; set; }
        public string CourseId { get; set; } = null!;

        public virtual Course Course { get; set; } = null!;
        public virtual User User { get; set; } = null!;
    }
}
