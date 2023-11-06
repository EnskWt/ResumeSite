using System.ComponentModel.DataAnnotations;

namespace ResumeSite.Models.ViewModels
{
    public class LoginObject
    {
        [Required]
        [Display(Name = "Username")]
        [StringLength(20, MinimumLength = 3)]
        public string Username { get; set; } = null!;

        [Required]
        [Display(Name = "Password")]
        [StringLength(20, MinimumLength = 8)]
        [DataType(DataType.Password)]
        public string Password { get; set; } = null!;
    }
}
