using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using JsonIgnoreAttribute = Newtonsoft.Json.JsonIgnoreAttribute;

namespace Database.Models
{
    public class User
    {
        [Key]
        [JsonIgnore]
        public int Id { get; set; }
        [Required]
        [JsonIgnore]
        public string UserId { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Email { get; set; }
        public string? SchoolName { get; set; }
        [JsonIgnore]
        public List<Subject>? Subjects { get; set; }
    }
}
