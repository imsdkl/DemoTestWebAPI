using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DemoTestWebAPI.Models
{
    public class Themes
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int ThemeNumber { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Category { get; set; }   // Required foreign Key property
        public Category Categories { get; set; } = null!;   // Required reference navigation to principal
    }
}
