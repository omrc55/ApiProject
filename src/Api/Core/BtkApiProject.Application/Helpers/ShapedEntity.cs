namespace BtkApiProject.Application.Helpers;

public record ShapedEntity
{
    public Guid? ID { get; set; }
    public Entity? Entity { get; set; }
}