using Business.Models;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers
{
  public class MembersController : Controller
  {
    //private readonly ClientService _clientService;

    [HttpPost]
    public IActionResult AddMember(AddMemberForm form)
    {
      if (!ModelState.IsValid)
      {
        var errors = ModelState
          .Where(x => x.Value?.Errors.Count > 0)
          .ToDictionary(
            kvp => kvp.Key,
            kvp => kvp.Value?.Errors.Select(x => x.ErrorMessage)
          );

        return BadRequest(new { success = false, errors });
      }

      //var result = await _clientService.AddMemberAsync(form);

      return Ok(new { success = true });

      //if (result)
      //{
      //  return Ok(new { success = true });
      //}
      //else
      //{
      //  return Problem("Unable to submit data.");
      //}

    }

    [HttpPost]
    public IActionResult EditMember(EditMemberForm form)
    {
      if (!ModelState.IsValid)
      {
        var errors = ModelState
          .Where(x => x.Value?.Errors.Count > 0)
          .ToDictionary(
            kvp => kvp.Key,
            kvp => kvp.Value?.Errors.Select(x => x.ErrorMessage)
          );

        return BadRequest(new { success = false, errors });
      }

      //var result = await _clientService.EditMemberAsync(form);

      return Ok(new { success = true });

      //if (result)
      //{
      //  return Ok(new { success = true });
      //}
      //else
      //{
      //  return Problem("Unable to submit data.");
      //}
    }  
  }
}
