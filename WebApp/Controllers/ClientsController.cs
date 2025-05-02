using Business.Models;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers
{
  public class ClientsController : Controller
  {
    //private readonly ClientService _clientService;

    [HttpPost]
    public IActionResult AddClient(AddClientForm form)
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

      //var result = await _clientService.AddClientAsync(form);

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
    public IActionResult EditClient(EditClientForm form)
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

      //var result = await _clientService.EditClientAsync(form);

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
