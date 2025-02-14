using API.Application.Commands;
using API.Application.Queries;
using API.Contracts;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("[controller]")]
public class ImageCatcherController(ILogger<ImageCatcherController> logger, ISender sender) : ControllerBase
{
    private readonly ILogger<ImageCatcherController> _logger = logger;

    [HttpPost]
    public async Task<ActionResult<int>> Store(AddImageCommand command)
    {
        var result = await sender.Send(command);

        return CreatedAtAction(nameof(Get), new { id = result }, result);
    }

    [HttpGet]
    public async Task<ActionResult<ImageRecord>> Get()
    {
        var image = await sender.Send(new GetImageQuery());
        if (image == null)
        {
            return NotFound("No image found.");
        }

        return Ok(image);
    }

    [HttpGet("LastEventsCount")]
    public async Task<ActionResult<int>> GetLastEventsCount()
    {
        var count = await sender.Send(new GetLastEventsCountQuery());

        return Ok(count);
    }
}