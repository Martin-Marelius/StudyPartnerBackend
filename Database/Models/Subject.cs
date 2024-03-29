using Newtonsoft.Json;
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
        public int Id { get; set; }
        [Required]
        public string SubjectId { get; set; }
        [Required]
        public string Title { get; set; }
        public string? Description { get; set; }
        [Required]
        public string SchoolName { get; set; }
        [Required]
        public string ColorCode { get; set; }
        [Required]
        public DateTime CreatedAt { get; set; }
        [Required]
        public int UpdatedBy { get; set; } // UserId
        [Required]
        public DateTime UpdatedAt { get; set; }
        [Required]
        public int UserId { get; set; } // UserId
        [ForeignKey("UserId")]
        public User User { get; set; }
        [JsonIgnore]
        public ICollection<Course>? Courses { get; set; }
        [JsonIgnore]
        public ICollection<Deadline>? Deadlines { get; set; }
    }
}
