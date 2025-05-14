using Business.Models;
using Business.Services;
using Domain.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers;

public class AuthController(IAuthService authService) : Controller
{
  private readonly IAuthService _authService = authService;

  public IActionResult Login()
  {
    return View();
  }

  [HttpPost]
  public async Task<IActionResult> Login(MemberLoginForm form)
  {
    if (ModelState.IsValid)
    {
      var result = await _authService.LoginAsync(form);
      if (result.Succeeded)
        return RedirectToAction("Projects", "Projects");
    }

    return View(form);
  }

  public IActionResult SignUp()
  {
    return View();
  }

  [HttpPost]
  public async Task<IActionResult> SignUp(MemberSignUpForm form)
  {
    if (ModelState.IsValid)
    {
      var result = await _authService.SignUpAsync(form);
      if (result.Succeeded)
        return RedirectToAction("Login", "Auth");
    }

    return View(form);
  }

  public async Task<IActionResult> Logout()
  {
    await _authService.LogoutAsync();
    return RedirectToAction("Login", "Auth");
  }
}
