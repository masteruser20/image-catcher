using API.Infrastructure;
using MediatR;

namespace API.Application.Commands;

public class AddImageHandler(IStore store) : IRequestHandler<AddImageCommand, int>
{
    public Task<int> Handle(AddImageCommand request, CancellationToken cancellationToken)
    {
        var count = store.AddImage(request.Description, request.ImageUrl);

        return Task.FromResult(count);
    }
}