
using System.ComponentModel.DataAnnotations;
using RequiredAttribute = System.ComponentModel.DataAnnotations.RequiredAttribute;

namespace zero_hunger.Models
{
    public class Signup
    {
        [Required]
        public string ResturentName { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        [MaxLength(50)]
        [RegularExpression(@"[a-z0-9._%+-]+@[a-z0-9.-]+\.[a-z]{2,4}", ErrorMessage = "Incorrect Email Format")]
        public string Email { get; set; }
        [Required]
        [MinLength(11, ErrorMessage = "Phone number is not valid")]
        [MaxLength(11, ErrorMessage = "Phone number is not valid")]
        public string Phone { get; set; }
        [Required]
        [DataType(DataType.Date)]
        [MinAge(18, ErrorMessage = "Age can not be less than 18 years")]
        public string DOB { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public string Gender { get; set; }
        [Required]
        public string Password { get; set; }
        [Required(ErrorMessage = "The Confirm-Password field is required")]
        [Compare("Password", ErrorMessage = "Confirm-Password Not Matched")]
        public string Confirm_Password { get; set; }
    }
}
