using System;
using System.Collections.Generic;

namespace BusinessObject.Models
{
    public partial class FavoriteSubject
    {
        public int UserId { get; set; }
        public string SubjectId { get; set; } = null!;

        public virtual Subject Subject { get; set; } = null!;
        public virtual User User { get; set; } = null!;
    }
}
