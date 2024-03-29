using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.Models
{
    public class Subject
    {
        [Key]
        public int SubjectId { get; set; }
        [Required]
        public string Title { get; set; }
        public string? Description { get; set; }
        [Required]
        public string SchoolName { get; set; }
        [Required]
        public string ColorCode { get; set; }
        [Required]
        public string CreatedBy { get; set; } // UserId
        public DateTime CreatedAt { get; set; }
        [Required]
        public string UpdatedBy { get; set; } // UserId
        public DateTime UpdatedAt { get; set; }
        public List<User>? Users { get; set; }
        public List<Course>? Courses { get; set; }
        public List<Deadline>? Deadlines { get; set; }

    }
}
