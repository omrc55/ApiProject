namespace BtkApiProject.Application.Helpers;

public record Pagination
{
    const int maxPageSize = 50;
    private int _pageSize;
    private int _pageNumber;

    public int PageNumber
    {
        get { return _pageNumber; }
        init { _pageNumber = value < 1 ? 1 : value; }
    }

    public int PageSize
    {
        get { return _pageSize; }
        init { _pageSize = Math.Clamp(value, 1, maxPageSize); }
    }
}