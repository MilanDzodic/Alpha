﻿using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace Business.Models;

public class EditMemberForm
{
  public int Id { get; set; }

  [Display(Name = "Member Image", Prompt = "Select an image")]
  [DataType(DataType.Upload)]
  public IFormFile? MemberImage { get; set; }

  [Display(Name = "Member Name", Prompt = "Enter member name")]
  [DataType(DataType.Text)]
  [Required(ErrorMessage = "Required")]
  public string MemberName { get; set; } = null!;

  [Display(Name = "Email", Prompt = "Enter email address")]
  [DataType(DataType.EmailAddress)]
  [Required(ErrorMessage = "Required")]
  [RegularExpression(@"^[^@\s]+@[^@\s]+\.[^@\s]+$", ErrorMessage = "Invalid Email")]
  public string Email { get; set; } = null!;

  [Display(Name = "Location", Prompt = "Enter location")]
  [DataType(DataType.Text)]
  public string? Location { get; set; }

  [Display(Name = "Phone", Prompt = "Enter phone number")]
  [DataType(DataType.PhoneNumber)]
  public string? Phone { get; set; }
}
