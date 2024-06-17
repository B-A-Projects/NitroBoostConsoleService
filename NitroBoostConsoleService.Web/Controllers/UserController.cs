using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using NitroBoostConsoleService.Shared.Logging;
using NitroBoostConsoleService.Shared.Dto;
using NitroBoostConsoleService.Shared.Exceptions;
using NitroBoostConsoleService.Shared.Interface.Service;

namespace NitroBoostConsoleService.Web.Controllers;

[ApiController]
[Route("api/console/[controller]")]
public class UserController : ControllerBase
{
    private IUserService _service;

    public UserController(IUserService service) => _service = service;

    [Authorize]
    [HttpGet]
    public async Task<ActionResult<UserDto?>> GetUser([FromQuery] string email)
    {
        if (!IsAuthorized(User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Email)?.Value, email))
            return Forbid();

        try
        {
            return Ok(await _service.GetUserByEmail(email));
        }
        catch (NotFoundException e)
        {
            Logger.Log(e.ToString(), Severity.Info);
            return NotFound();
        }
        catch (InvalidDataException e)
        {
            Logger.Log(e.ToString(), Severity.Warning);
            return BadRequest();
        }
        catch (Exception e)
        {
            Logger.Log(e.ToString(), Severity.Error);
            throw;
        }
    }
    
    private bool IsAuthorized(string? identityEmail, string requestEmail)
    {
        if (identityEmail == null) 
            return false;
        return identityEmail == requestEmail;
    }
}