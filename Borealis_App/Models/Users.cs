using System.ComponentModel.DataAnnotations;

namespace Borealis_App.Models
{
    public class Users
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Username { get; set; }
        [Required]
        public string lozinka { get; set; }
    }
}