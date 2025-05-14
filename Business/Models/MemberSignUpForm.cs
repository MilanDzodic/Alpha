using System.ComponentModel.DataAnnotations;

namespace Business.Models;

public class MemberSignUpForm
{
  [Required(ErrorMessage = "Required")]
  [DataType(DataType.Text)]
  [Display(Name = "First name", Prompt = "Enter first name")]
  public string FirstName { get; set; } = null!;

  [Required(ErrorMessage = "Required")]
  [DataType(DataType.Text)]
  [Display(Name = "Last name", Prompt = "Enter last name")]
  public string LastName { get; set; } = null!;

  [Required(ErrorMessage = "Required")]
  [DataType(DataType.EmailAddress)]
  [Display(Name = "Email", Prompt = "Enter email address")]
  [RegularExpression(@"^[^@\s]+@[^@\s]+\.[^@\s]+$", ErrorMessage = "Invalid Email")]
  public string Email { get; set; } = null!;

  [DataType(DataType.PhoneNumber)]
  [Display(Name = "Phone", Prompt = "Enter phone number")]
  public string? Phone { get; set; }

  [Required(ErrorMessage = "Required")]
  [DataType(DataType.Password)]
  [Display(Name = "Password", Prompt = "Enter password")]
  //[RegularExpression] (@"", ErrorMessage: "Invalid Password")]
  public string Password { get; set; } = null!;

  [Required(ErrorMessage = "Required")]
  [DataType(DataType.Password)]
  [Display(Name = "Confirm Password", Prompt = "Enter password")]
  [Compare(nameof(Password), ErrorMessage = "Passwords don't match!")]
  public string ConfirmPassword { get; set; } = null!;

  [Range(typeof(bool), "true", "true")]
  public bool TermsAndConditions { get; set; }
}
