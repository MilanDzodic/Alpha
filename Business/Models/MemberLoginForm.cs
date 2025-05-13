using System.ComponentModel.DataAnnotations;

namespace Business.Models;

public class MemberLoginForm
{
  [Required(ErrorMessage = "Required")]
  [Display(Name = "Email", Prompt = "Enter email address")]
  [DataType(DataType.EmailAddress)]
  [RegularExpression(@"^[^@\s]+@[^@\s]+\.[^@\s]+$", ErrorMessage = "Invalid Email")]
  public string Email { get; set; } = null!;

  [Required(ErrorMessage = "Required")]
  [DataType(DataType.Password)]
  [Display(Name = "Password", Prompt = "Enter password")]
  //[RegularExpression](@"", ErrorMessage: "Invalid Password")]
  public string Password { get; set; } = null!;

  public bool IsPersistent { get; set; }
}
