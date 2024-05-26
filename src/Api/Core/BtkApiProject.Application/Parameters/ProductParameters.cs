namespace BtkApiProject.Application.Parameters;

public record ProductParameters : RequestParameters
{
    public bool AddProductDetail { get; init; } = false;
    public bool AddCategory { get; init; } = false;
    public bool AddOrders { get; init; } = false;
    public uint? MinPrice { get; init; } = null;
    public uint? MaxPrice { get; init; } = null;
    public uint? MinQuantity { get; init; } = null;
    public uint? MaxQuantity { get; init; } = null;
    public List<string>? CategoryIDs { get; init; } = null;
    public bool ValidCategoryIDs => CategoryIDs is not null && CategoryIDs.All(IsGuid);
    public bool ValidPriceRange => MaxPrice > MinPrice || MinPrice is null || MaxPrice is null;
    public bool ValidQuantity => MaxQuantity > MinQuantity || MinQuantity is null || MaxQuantity is null;

    private static bool IsGuid(string input)
    {
        return Guid.TryParse(input, out _);
    }
}