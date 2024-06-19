namespace BtkApiProject.Application.Helpers.Links;

public record LinkResponse
{
    public bool HasLinks { get; init; }
    public List<Entity?>? ShapedEntities { get; init; }
    public LinkCollectionWrapper<Entity?>? LinkedEntities { get; init; }
}