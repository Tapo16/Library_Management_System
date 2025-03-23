using System.ComponentModel.DataAnnotations;

namespace Library_Management_System.Models
{
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }

        [MaxLength(20)]
        public string? CatName { get; set; }
    }
}