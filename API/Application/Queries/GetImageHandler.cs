using API.Application.Commands;
using API.Contracts;
using API.Infrastructure;
using MediatR;

namespace API.Application.Queries;

public class GetImageHandler(IStore store) : IRequestHandler<GetImageQuery, ImageRecord?>
{
    public Task<ImageRecord?> Handle(GetImageQuery request, CancellationToken cancellationToken)
    {
        var image = store.GetLastImage();

        return Task.FromResult(image);
    }
}