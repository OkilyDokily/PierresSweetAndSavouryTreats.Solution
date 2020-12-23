using System.ComponentModel.DataAnnotations;

namespace PierresSweetAndSavouryTreats.ViewModels
{
  public class RegisterViewModel
  {
    [Required(ErrorMessage = "This field is required.")]
    public string Email { get; set; }
    
    [Required(ErrorMessage = "This field is required.")]
    public string Password { get; set; }

    [Required(ErrorMessage = "This field is required.")]
    [Compare("Password",ErrorMessage = "Passwords don't match.")]
    [Display(Name = "Matching Password")]
    public string PasswordMatch { get; set; }
  }
}