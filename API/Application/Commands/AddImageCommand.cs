using MediatR;

namespace API.Application.Commands;

public record AddImageCommand : IRequest<int>
{
    public string Description { get; init; } = null!;

    public string ImageUrl { get; init; } = null!;
}