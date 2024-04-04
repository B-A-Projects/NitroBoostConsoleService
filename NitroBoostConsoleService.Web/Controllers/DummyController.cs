using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata.Ecma335;

namespace NitroBoostConsoleService.Web.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DummyController : ControllerBase
    {
        [HttpGet("helloworld")]
        public ActionResult<string> Index() => Ok("Hello World!");
    }
}
