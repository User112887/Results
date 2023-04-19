namespace GhostBackendStarterPack.Results;

/// <summary>
/// Abstraction of paged results
/// </summary>
/// <typeparam name="TDataModel">Type of data returned</typeparam>
/// <typeparam name="TErrorModel">Type of the errors that can be had</typeparam>
public interface IPagedResult<TDataModel, TErrorModel>
{

    /// <summary>
    /// Was the request succeesfull
    /// </summary>
    bool Succeeded { get; set; }

    /// <summary>
    /// Success Result
    /// </summary>
    IEnumerable<TDataModel> Data { get; set; }

    /// <summary>
    /// Erros if any
    /// </summary>
    IEnumerable<TErrorModel> Errors { get; set; }

    /// <summary>
    /// Current page the data was read from
    /// </summary>
    int Page { get; set; }

    /// <summary>
    /// Size of the page read from
    /// </summary>
    int PageSize { get; set; }

    /// <summary>
    /// Total count of all items
    /// </summary>
    int TotalCount { get; set; }
}
