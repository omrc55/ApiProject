using BtkApiProject.Common.DTOs.Orders;

namespace BtkApiProject.Common.DTOs.Joins;

public record OrdersForProductDTO
{
    public Guid? OrderID { get; init; }
    public virtual OrderResponseForProductDTO? Order { get; init; }
}