namespace API.Contracts;

public record ImageRecord
{
    public string Description { get; init; } = null!;

    public string ImageSrc { get; init; } = null!;
}