using System.ComponentModel.DataAnnotations;

namespace CoreMiniProject.Models
{
    public class UserViewModel
    {
        [Required]
        public string Name { get; set; }

        [Required]
        [DataType(DataType.Password)] 
        public string Password { get; set; }


        [Required]
        [DataType(DataType.Password)]
        [Display(Name="Confirm Password")]
        [Compare("Password", ErrorMessage ="Confirm Password shoud match with Password")]
        public string ConfirmPassword { get; set; }


        [Required]
        [EmailAddress]
        public string Email { get; set; }


        [Required]
        [RegularExpression("[6-9]\\d{9}", ErrorMessage = "Mobile No. Is Invalid")]

        public string Mobile { get; set; 
        
        }
    }
}
