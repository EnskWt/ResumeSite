using System.ComponentModel.DataAnnotations;

namespace ResumeSite.Models.ViewModels
{
    public class RegisterObject
    {
        [Required]
        [Display(Name = "Username")]
        [StringLength(20, MinimumLength = 3)]
        public string Username { get; set; } = null!;

        [Required]
        [Display(Name = "Email")]
        [StringLength(50, MinimumLength = 5)]
        [EmailAddress]
        public string Email { get; set; } = null!;

        [Required]
        [Display(Name = "Phone Number")]
        [StringLength(20, MinimumLength = 10)]
        [Phone]
        public string PhoneNumber { get; set; } = null!;

        [Required]
        [Display(Name = "Password")]
        [StringLength(20, MinimumLength = 8)]
        [DataType(DataType.Password)]
        public string Password { get; set; } = null!;

        [Required]
        [Display(Name = "Confirm Password")]
        [StringLength(20, MinimumLength = 8)]
        [DataType(DataType.Password)]
        [Compare("Password")]
        public string ConfirmPassword { get; set; } = null!;
    }
}
