namespace BtkApiProject.Application.Parameters;

public record ProductParameters : RequestParameters
{
    public bool AddProductDetail { get; init; } = false;
    public bool AddCategory { get; init; } = false;
    public bool AddOrders { get; init; } = false;
}