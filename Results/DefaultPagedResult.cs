using Results.Parameters;

namespace GhostBackendStarterPack.Results;

public class DefaultPagedResult<TDataModel> : IDefaultPagedResult<TDataModel>
{

    /// <summary>
    /// Gets or sets Succeeded
    /// </summary>
    public bool Succeeded { get; set; }
    
    /// <summary>
    /// Gets or sets Data
    /// </summary>
    public IEnumerable<TDataModel> Data { get; set; }
    
    /// <summary>
    /// Gets or sets Errors
    /// </summary>
    public IEnumerable<string> Errors { get; set; }
    
    /// <summary>
    /// Gets or sets Page
    /// </summary>
    public int Page { get; set; }
    
    /// <summary>
    /// Gets or sets PageSize
    /// </summary>
    public int PageSize { get; set; }
    
    /// <summary>
    /// Gets or sets TotalCount
    /// </summary>
    public int TotalCount { get; set; }

    /// <summary>
    /// Generates a Failed result
    /// </summary>
    /// <param name="errors">Erorrs that caused the fail</param>
    /// <returns>Fail result with default values for the data</returns>
    public static DefaultPagedResult<TDataModel> Fail(IEnumerable<string> errors)
    {
        return new DefaultPagedResult<TDataModel>
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
    public static DefaultPagedResult<TDataModel> Fail(string error)
    {
        return new DefaultPagedResult<TDataModel>
        {
            Data = default,
            Errors = new List<string> { error },
            Succeeded = false,
        };
    }

    /// <summary>
    /// Generates a success result
    /// </summary>
    /// <param name="data">Data returned from action</param>
    /// <returns>A result with data equal to the data returned from action</returns>
    public static DefaultPagedResult<TDataModel> Success(IEnumerable<TDataModel> data, int totalCount, PagedParameters pagedParameters)
    {
        return new DefaultPagedResult<TDataModel>
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