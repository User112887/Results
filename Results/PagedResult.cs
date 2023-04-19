using Results.Parameters;

namespace GhostBackendStarterPack.Results;

/// <summary>
/// Implementation of IResult
/// </summary>
/// <typeparam name="TData">Data to be returned when no erros</typeparam>
/// <typeparam name="TErorrModel">Type of error to returned when errors are present</typeparam>
public class PagedResult<TData, TErorrModel> : IPagedResult<TData, TErorrModel>
{

    /// <summary>
    /// Was the request successful
    /// </summary>
    public bool Succeeded { get; set; }

    /// <summary>
    /// Data returened in case it was successful
    /// </summary>
    public IEnumerable<TData> Data { get; set; }

    /// <summary>
    /// Total count of all items
    /// </summary>
    public int TotalCount { get; set; }

    /// <summary>
    /// Size of the current read page
    /// </summary>
    public int PageSize { get; set; }

    /// <summary>
    /// Page we are reading from
    /// </summary>
    public int Page { get; set; }

    /// <summary>
    /// Errors in case we have errors
    /// </summary>
    public IEnumerable<TErorrModel> Errors { get; set; }

    /// <summary>
    /// Generates a Failed result
    /// </summary>
    /// <param name="errors">Erorrs that caused the fail</param>
    /// <returns>Fail result with default values for the data</returns>
    public static PagedResult<TData, TErorrModel> Fail(IEnumerable<TErorrModel> errors)
    {
        return new PagedResult<TData, TErorrModel>
        {
            Data = default,
            Errors = errors,
            Succeeded = false
        };
    }

    /// <summary>
    /// Generates a Failed result
    /// </summary>
    /// <param name="error">The error that caused the fail</param>
    /// <returns>Fail result with default values for the data</returns>
    public static PagedResult<TData, TErorrModel> Fail(TErorrModel error)
    {
        return new PagedResult<TData, TErorrModel>
        {
            Data = default,
            Errors = new List<TErorrModel> { error },
            Succeeded = false,
        };
    }

    /// <summary>
    /// Generates a success result
    /// </summary>
    /// <param name="data">Data returned from action</param>
    /// <returns>A result with data equal to the data returned from action</returns>
    public static PagedResult<TData, TErorrModel> Success(IEnumerable<TData> data, int totalCount, PagedParameters pagedParameters)
    {
        return new PagedResult<TData, TErorrModel>
        {
            Data = data,
            Succeeded = true,
            Errors = default,
            TotalCount = totalCount,
            Page = pagedParameters.Page,
            PageSize = pagedParameters.PageSize
        };
    }

    /// <summary>
    /// Checks if paged parameters can generate a valid page with valid results
    /// </summary>
    /// <param name="pagedParameters">Paraneters to check if they are valid</param>
    /// <returns>List of errors</returns>
    public static List<string> IsValidPagedParameter(PagedParameters pagedParameters)
    {
        List<string> errors = new List<string>();

        if (pagedParameters.PageSize < 0)
            errors.Add("Page size should be greater than or 0");


        if (pagedParameters.Page < 1)
            errors.Add("Page number should be greater than or 1");

        return errors;
    }
}
