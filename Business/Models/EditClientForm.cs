﻿using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace Business.Models;

public class EditClientForm
{
  public int Id { get; set; }

  [Display(Name = "Client Image", Prompt = "Select an image")]
  [DataType(DataType.Upload)]
  public IFormFile? ClientImage { get; set; }

  [Display(Name = "Client Name", Prompt = "Enter client name")]
  [DataType(DataType.Text)]
  [Required(ErrorMessage = "Required")]
  public string ClientName { get; set; } = null!;

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
