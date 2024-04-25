namespace BtkApiProject.Domain.Entities.Common;

public abstract class BaseEntity
{
    public Guid ID { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime? UpdatedDate { get; set; }
    public bool IsApproved { get; set; }
    public bool IsDeleted { get; set; }
}
