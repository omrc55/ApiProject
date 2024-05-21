using BtkApiProject.Application.Helpers;

namespace BtkApiProject.Application.Parameters;

public record RequestParameters
{
    public required Pagination Pagination { get; init; }
    public bool? IsApproved { get; init; } = null;
    public bool? IsDeleted { get; init; } = null;
}