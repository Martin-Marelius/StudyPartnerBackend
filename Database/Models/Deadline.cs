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
    public class Deadline
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string DeadlineId { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public DateTime DueDate { get; set; }
        [Required]
        [ForeignKey("SubjectId")]
        public int SubjectId { get; set; }
        public Subject Subject { get; set; }
    }
}
