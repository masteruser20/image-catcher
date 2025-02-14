namespace API.Contracts;

public record ImageRecord
{
    public string Description { get; init; } = null!;

    public string ImageSrc { get; init; } = null!;
    
    public DateTime CreatedAt { get; init; } = DateTime.Now;
}