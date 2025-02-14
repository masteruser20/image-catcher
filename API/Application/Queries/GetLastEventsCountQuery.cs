using MediatR;

namespace API.Application.Queries;

public record GetLastEventsCountQuery : IRequest<int>
{
}