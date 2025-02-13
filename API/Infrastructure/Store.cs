using API.Contracts;

namespace API.Infrastructure;

public class Store : IStore
{
    private readonly List<ImageRecord> _images = new();

    public int AddImage(string description, string imageSrc)
    {
        _images.Add(new ImageRecord
        {
            Description = description,
            ImageSrc = imageSrc
        });
        return _images.Count;
    }

    public ImageRecord GetLastImage()
    {
        return _images.Last();
    }
}