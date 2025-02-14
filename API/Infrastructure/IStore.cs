using API.Contracts;

namespace API.Infrastructure;

public interface IStore
{
    public int AddImage(string description, string imageSrc);

    public ImageRecord? GetLastImage();
    
    int GetLastEventsCount();
}