using BtkApiProject.Common.DTOs.Common;

namespace BtkApiProject.Common.DTOs.Categories;

public record CategoryResponseForProductDTO : BaseResponseDTO
{
    public string? Name { get; init; }
    public string? Description { get; init; }
}
