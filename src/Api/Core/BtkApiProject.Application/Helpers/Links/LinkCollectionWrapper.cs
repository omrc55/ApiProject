namespace BtkApiProject.Application.Helpers.Links;

public record LinkCollectionWrapper<T> : LinkResourceBase
{
    public List<T?>? Value { get; init; }

    public LinkCollectionWrapper() { }

    public LinkCollectionWrapper(List<T?>? value)
    {
        Value = value;
    }
}