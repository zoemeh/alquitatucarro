using System.ComponentModel.DataAnnotations;

namespace AlquitaTuCarro.Models
{
    public class FuelType
    {
        public int Id { get; set; }
        [Required]
        [Uniq]
        public string? Description { get; set; } 
        public bool IsActive { get; set; }  

    }
}
