using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Library_Management_System.Models
{
    public class Book
    {
        [Key]
        public int BookId { get; set; }

        [MaxLength(20)]
        public string BookName { get; set; }

        [MaxLength(20)]
        public string AuthorName { get; set; }

        [MaxLength(20)]
        public string PublisherName { get; set; }


        [Display(Name="Date Of Publish")]
        [DataType(DataType.Date)]
        public DateTime Dop { get; set; }

        public int Stock { get; set; }

        public int Availability { get; set; }

        public int Cid { get; set; }

        [NotMapped]
        public string? CategoryName { get; set; }

        [Display(Name = "Book Img")]
        public string? BookFilePath { get; set; }

        [NotMapped]
        public IFormFile BookFile { get; set; }
    }
}