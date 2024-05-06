namespace BtkApiProject.Common.DTOs.Common;

public abstract record BaseResponseDTO
{
    public Guid ID { get; init; }
    public DateTime CreatedDate { get; init; }
    public DateTime? UpdatedDate { get; init; }
    public bool IsApproved { get; init; }
    public bool IsDeleted { get; init; }
}
