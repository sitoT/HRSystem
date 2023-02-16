using System.ComponentModel.DataAnnotations;

namespace HRSystem.Models
{
    public class Staff
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Position { get; set; }
    }
}
