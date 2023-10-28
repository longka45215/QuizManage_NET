using System;
using System.Collections.Generic;

namespace BusinessObject.Models
{
    public partial class RoleName
    {
        public RoleName()
        {
            Users = new HashSet<User>();
        }

        public int RoleId { get; set; }
        public string RoleName1 { get; set; } = null!;

        public virtual ICollection<User> Users { get; set; }
    }
}
