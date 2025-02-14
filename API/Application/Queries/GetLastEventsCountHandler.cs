using API.Infrastructure;
using MediatR;

namespace API.Application.Queries;

public class GetLastEventsCountHandler(IStore store) : IRequestHandler<GetLastEventsCountQuery, int>
{
    public Task<int> Handle(GetLastEventsCountQuery request, CancellationToken cancellationToken)
    {
        var count = store.GetLastEventsCount();

        return Task.FromResult(count);
    }
}