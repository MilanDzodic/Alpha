using System.Threading.Tasks;
using Business.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers;

//[Authorize]
[Route("admin")]
public class AdminController(IMemberService memberService) : Controller
{
  private readonly IMemberService _memberService = memberService;

  //[Authorize(Roles = "admin")]
  [Route("members")]
  public async Task<IActionResult> Members()
  {
    var members = await _memberService.GetAllMembers();

    return View(members);
  }

  //[Authorize(Roles = "admin")]
  [Route("clients")]
  public IActionResult Clients()
  {
    return View();
  }
}