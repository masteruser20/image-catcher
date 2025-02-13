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
    public async Task<int> Store(AddImageCommand command)
    {
        return await sender.Send(command);
    }

    [HttpGet]
    public async Task<ImageRecord> Get()
    {
        return await sender.Send(new GetImageQuery());
    }
}