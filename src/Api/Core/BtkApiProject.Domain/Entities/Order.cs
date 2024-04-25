using BtkApiProject.Domain.Entities.Common;
using BtkApiProject.Domain.Entities.Joins;

namespace BtkApiProject.Domain.Entities;

public class Order : BaseEntity
{
    public virtual ICollection<OrderProduct>? OrderProducts { get; set; }
}
