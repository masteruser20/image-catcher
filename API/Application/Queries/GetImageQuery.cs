using API.Contracts;
using MediatR;

namespace API.Application.Queries;

public record GetImageQuery : IRequest<ImageRecord?>
{
}