using System.ComponentModel.DataAnnotations;

namespace Magazyn.Models
{
    public class Item
    {

        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }

        [Required]
        public decimal Quantity { get; set; }
        [Required]
        public decimal Cost { get; set; }

        
        public string? Image { get; set; } 
    }
}