using Business.Services;
using Domain.Models;
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
      if (result)
        return RedirectToAction("Projects", "Projects");
    }

    //var errors = ModelState
    //.Where(x => x.Value?.Errors.Count > 0)
    //.ToDictionary(
    //  kvp => kvp.Key,
    //  kvp => kvp.Value?.Errors.Select(x => x.ErrorMessage));

    //return BadRequest(new { success = false, errors });

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
      if (result)
        return RedirectToAction("Login", "Auth");
    }

    //var errors = ModelState
    //.Where(x => x.Value?.Errors.Count > 0)
    //.ToDictionary(
    //kvp => kvp.Key,
    //kvp => kvp.Value?.Errors.Select(x => x.ErrorMessage));

    //return BadRequest(new { success = false, errors });

    return View(form);
  }

  public async Task<IActionResult> Logout()
  {
    await _authService.LogoutAsync();
    return RedirectToAction("Login", "Auth");
  }
}
