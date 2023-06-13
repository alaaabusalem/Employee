using System.ComponentModel.DataAnnotations;

namespace Employee.Models
{
    public class Employees

    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        
        public string Email { get; set; }
        [Required]  
        public  Dept ? Department { get; set; }
        public string ? PhotoPath { get; set; } = string.Empty;

	}
}
