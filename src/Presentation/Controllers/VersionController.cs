using SolutionNamePlaceholder.Application.Version.Queries.GetCurrentVersion;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SolutionNamePlaceholder.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VersionController(IMediator mediator) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetVersion()
        {
            var version = await mediator.Send(new GetCurrentVersionQuery());
            return Ok(new { Version = version });
        }
    }
}
