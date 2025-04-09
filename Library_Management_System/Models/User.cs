using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Library_Management_System.Models
{
    public class User
    {

         [MaxLength(20)]
         public string Name { get; set; }


         [MaxLength(1)]
         public string Gender { get; set; }

         [Key]
         [MaxLength(20)]
         [DataType(DataType.EmailAddress)]
         public string Email { get; set; }

         [DataType(DataType.Password)]
      //  [RegularExpression("^(?=.*[0-9])(?=.*[a-z])(?=.*[A-Z])(?=.*[\\W_]).{6,10}$",
  //   ErrorMessage = "Password must be between 6 and 10 characters and contain one uppercase letter, one lowercase letter, one digit and one special character.")]

        [MaxLength(20)]
         public string Password { get; set; }

        
        [DataType(DataType.Password)]
        [Compare("Password")]
      //  [RegularExpression("^(?=.*[0-9])(?=.*[a-z])(?=.*[A-Z])(?=.*[\\W_]).{6,10}$",
  //   ErrorMessage = "Password must be between 6 and 10 characters and contain one uppercase letter, one lowercase letter, one digit and one special character.")]

        [MaxLength(20)]
        [NotMapped]
        public string ReTypePaasword { get; set; }


        [DataType(DataType.Date)]
        public DateTime Dob { get; set; }

        [MaxLength(250)]
        public string SecurityQuestion { get; set; }

        [MaxLength(50)]
        public string SecurityAns { get; set; }


        // new column to track deactivate or not
        public bool isDeactivated { get; set; } = false;
    }
}