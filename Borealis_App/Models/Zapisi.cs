using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Borealis_App.Models
{
    public class Zapisi
    {
        [Key]
        public int IDzapisa { get; set; }
        [Required]
        public string Ime { get; set; }
        [Required]
        public string Prezime { get; set; }
        [Required]
        public decimal vrijeme { get; set; }
        public bool Prihvaceno { get; set; } = false;
    }
}
