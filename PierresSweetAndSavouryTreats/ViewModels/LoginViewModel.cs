using System.ComponentModel.DataAnnotations;

namespace PierresSweetAndSavouryTreats.ViewModels
{
  public class LoginViewModel
  {
    [Required(ErrorMessage = "This field is required.")]
    public string Email { get; set; }
    [Required(ErrorMessage = "This field is required.")]
    public string Password { get; set; }
  }
}