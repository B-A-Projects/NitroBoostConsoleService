using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NitroBoostConsoleService.Data;
using NitroBoostConsoleService.Data.Entities;
using NitroBoostConsoleService.Shared.Dto;

namespace NitroBoostConsoleService.Web.Controllers
{
    [ApiController]
    [Route("api/console/[controller]")]
    public class DummyController : ControllerBase
    {
        [HttpGet("helloworld")]
        public ActionResult<string> Index() => Ok("Hello World!");

        // [HttpGet("database")]
        // public async Task<ActionResult<string>> TestDatabaseConnection()
        // {
        //     try
        //     {
        //         var options = new DbContextOptionsBuilder<NitroboostConsoleContext>().UseNpgsql(
        //             "Host=localhost;Database=nitroboost-console;Username=blurrito;Password=YCR-200400;").Options;
        //         var context = new NitroboostConsoleContext(options);
        //         Device? device = await context.Set<Device>().Where(x => x.Id == 1).FirstOrDefaultAsync();
        //         return Ok("Successfully connected!");
        //     }
        //     catch (Exception e)
        //     {
        //         return BadRequest(e.Message);
        //     }
        // }
    }
}
