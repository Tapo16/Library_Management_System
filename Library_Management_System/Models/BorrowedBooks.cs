using System.ComponentModel.DataAnnotations;

namespace Library_Management_System.Models
{
    public class BorrowedBooks
    {
        [Key]
        public int Id { get; set; }
        public int BookId { get; set; }
        public string BookName { get; set; }
        public string UserEmail { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime BorrowDate { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime? ReturnDate { get; set; }
    }
}