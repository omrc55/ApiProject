namespace BtkApiProject.Domain.Entities.Joins;

public class OrderProduct
{
    public required Guid OrderID { get; set; }
    public virtual Order? Order { get; set; }

    public required Guid ProductID { get; set; }
    public virtual Product? Product { get; set; }
}
