using System.Collections.Concurrent;
using API.Contracts;

namespace API.Infrastructure;

public class Store : IStore
{
    private static readonly ConcurrentBag<ImageRecord> _images = new();

    public int AddImage(string description, string imageSrc)
    {
        _images.Add(new ImageRecord
        {
            Description = description,
            ImageSrc = imageSrc
        });
        return _images.Count;
    }

    public ImageRecord? GetLastImage()
    {
        if (_images.Count == 0)
        {
            return null;
        }
        
        return _images.Last();
    }

    public int GetLastEventsCount()
    {
        return _images.Count(image => image?.CreatedAt > DateTime.Now.AddHours(-1));
    }
}