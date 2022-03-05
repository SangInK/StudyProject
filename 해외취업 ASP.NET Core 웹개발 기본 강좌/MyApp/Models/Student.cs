using System.ComponentModel.DataAnnotations;

namespace MyApp.Models
{
    public class Student
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [Range(12, 70)]
        public int Age { get; set; } 

        [Required]
        [MinLength(5)]
        public string Country { get; set; }
    }
}
