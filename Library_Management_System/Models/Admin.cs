using System.ComponentModel.DataAnnotations;

namespace Library_Management_System.Models
{
    public class Admin
    {

        [Key]
        [MaxLength(20)]
        [DataType(DataType.EmailAddress)]
        public string? Email { get; set; }

        [DataType(DataType.Password)]
        [RegularExpression("^(?=.*[0-9])(?=.*[a-z])(?=.*[A-Z])(?=.*[\\W_]).{6,10}$",
     ErrorMessage = "Password must be between 6 and 10 characters and contain one uppercase letter, one lowercase letter, one digit and one special character.")]

        public string Password { get; set; }
    }
}