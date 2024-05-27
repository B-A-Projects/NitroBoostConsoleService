using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NitroBoostConsoleService.Shared.Dto;
using NitroBoostConsoleService.Shared.Interface.Service;

namespace NitroBoostConsoleService.Web.Controllers;

[ApiController]
[Route("api/console/[controller]")]
public class DeviceController : ControllerBase
{
    private IDeviceService _service;

    public DeviceController(IDeviceService service) => _service = service;

    [HttpGet("dummy")]
    [Authorize]
    public ActionResult<string> Dummy() => Ok("Successfully authorized!");
    
    [HttpGet]
    [Authorize]
    public async Task<ActionResult<DeviceDto?>> GetDeviceById([FromQuery] long id)
    {
        DeviceDto? device = await _service.GetDeviceById(id, GetUserId());
        if (device == null)
            return NotFound();
        return Ok(device!);
    }
    
    [HttpPost]
    [Authorize]
    public async Task<ActionResult<DeviceDto?>> AddDevice([FromBody] DeviceDto device) => 
        Ok(await _service.AddDevice(device, GetUserId()));
    
    [HttpPut]
    [Authorize]
    public async Task<ActionResult<DeviceDto?>> UpdateDevice([FromBody] DeviceDto device) => 
        Ok(await _service.UpdateDevice(device, GetUserId()));

    [HttpDelete]
    [Authorize]
    public async Task<ActionResult> DeleteDevice([FromBody] DeviceDto device)
    {
        await _service.DeleteDevice(device.Id ?? 0, GetUserId());
        return Ok();
    }

    private long GetUserId()
    {
        string? claimValue = GetTokenClaim("id")?.Value;
        if (claimValue == null)
            return 0;

        long result = 0;
        if (!long.TryParse(claimValue, out result))
            return 0;
        return result;
    }
    
    private Claim? GetTokenClaim(string claimType)
    {
        if (HttpContext.User.Identity == null)
            return null;
        
        ClaimsIdentity? user = (ClaimsIdentity)HttpContext.User.Identity;
        return user.FindFirst(claimType) ?? null;
    }
}