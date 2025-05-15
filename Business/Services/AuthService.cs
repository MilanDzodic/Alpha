using Business.Models;
using Data.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Business.Services;

public interface IAuthService
{
  Task<AuthResult> LoginAsync(MemberLoginForm loginForm);
  Task LogoutAsync();
  Task<AuthResult> SignUpAsync(MemberSignUpForm signupForm);
}

public class AuthService(SignInManager<MemberEntity> signInManager, IMemberService memberService) : IAuthService
{
  private readonly SignInManager<MemberEntity> _signInManager = signInManager;
  private readonly IMemberService _memberService = memberService;

  public async Task<AuthResult> LoginAsync(MemberLoginForm loginForm)
  {
    if (loginForm == null)
      return new AuthResult { Succeeded = false, StatusCode = 400, Error = "Not all required fields are supplied." };

    var result = await _signInManager.PasswordSignInAsync(loginForm.Email, loginForm.Password, loginForm.IsPersistent, false);
    return result.Succeeded
      ? new AuthResult() { Succeeded = true, StatusCode = 201 }
      : new AuthResult() { Succeeded = false, StatusCode = 401, Error = "Invalid email or password" };
  }

  public async Task<AuthResult> SignUpAsync(MemberSignUpForm signupForm)
  {
    if (signupForm == null)
      return new AuthResult { Succeeded = false, StatusCode = 400, Error = "Not all required fields are supplied." };

    var result = await _memberService.CreateMemberAsync(signupForm);
    return result.Succeeded
      ? new AuthResult() { Succeeded = true, StatusCode = 201 }
      : new AuthResult() { Succeeded = false, StatusCode = result.StatusCode, Error = result.Error };
  }

  public async Task LogoutAsync()
  {
    await _signInManager.SignOutAsync();
  }
}
