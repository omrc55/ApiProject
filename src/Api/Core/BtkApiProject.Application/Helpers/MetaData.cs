namespace BtkApiProject.Application.Helpers;

public record MetaData
{
    public int TotalCount { get; init; }
    public int TotalPage => (int)Math.Ceiling(TotalCount / (double)PageSize);
    public int CurrentPage { get; init; }
    public int PageSize { get; init; }

    public bool HasPrevious => CurrentPage > 1;
    public bool HasNext => CurrentPage < TotalPage;
}