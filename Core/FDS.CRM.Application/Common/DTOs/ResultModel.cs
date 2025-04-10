namespace FDS.CRM.Application.Common.DTOs;

public record ResultModel<T>(T Data, bool IsError = false, string ErrorMessage = default!, int Status = 200) where T : notnull
{
    public static ResultModel<T> Create(T? data, bool isError = false, string errorMessage = default!, int status = 200)
    {
        return new(data, isError, errorMessage, status);
    }
}

public record ListResultModel<T>(List<T> Items, long TotalItems, int CurrentPage, int PageSize, int TotalPages) where T : notnull
{
    public static ListResultModel<T> Create(List<T> items, long totalItems = 0, int currentPage = 1, int pageSize = 20, int totalPages = 1)
    {
        return new(items, totalItems, currentPage, pageSize, totalPages);
    }
}
