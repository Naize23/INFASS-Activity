using System.ComponentModel.DataAnnotations;

namespace INFASS_Activity.Models
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "Full name is required.")]
        [StringLength(
           100,
           MinimumLength = 2,
           ErrorMessage = "Full name must contain at least 2 characters."
       )]
        [Display(Name = "Full Name")]
        public string FullName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Username is required.")]
        [StringLength(
            30,
            MinimumLength = 4,
            ErrorMessage = "Username must contain between 4 and 30 characters."
        )]
        public string Username { get; set; } = string.Empty;

        [Required(ErrorMessage = "Email address is required.")]
        [EmailAddress(ErrorMessage = "Enter a valid email address.")]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = "Password is required.")]
        [StringLength(
            50,
            MinimumLength = 6,
            ErrorMessage = "Password must contain at least 6 characters."
        )]
        [DataType(DataType.Password)]
        public string Password { get; set; } = string.Empty;

        [Required(ErrorMessage = "Please confirm your password.")]
        [DataType(DataType.Password)]
        [Display(Name = "Confirm Password")]
        [Compare(
            nameof(Password),
            ErrorMessage = "Password and confirmation password do not match."
        )]
        public string ConfirmPassword { get; set; } = string.Empty;
    }
}
