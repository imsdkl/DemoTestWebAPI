using System.ComponentModel.DataAnnotations;

namespace DemoTestWebAPI.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public ICollection<Themes> Themes { get; set; }    // Collection navigation containing dependents
    }
}
