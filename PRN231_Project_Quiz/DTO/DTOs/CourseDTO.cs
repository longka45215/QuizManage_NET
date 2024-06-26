﻿using BusinessObject.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.DTOs
{
    public class CourseDTO
    {
        [Key]
        public string CourseId { get; set; } = null!;
        public string CourseName { get; set; } = null!;
        public string? Description { get; set; }
        public int CategoryId { get; set; }
        public string? Thumbnail { get; set; }
        public virtual CourseCategoryDTO Category { get; set; } = null!;
    }
}
