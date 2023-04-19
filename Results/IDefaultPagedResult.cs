namespace GhostBackendStarterPack.Results;

public interface IDefaultPagedResult<TDataModel>
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
    IEnumerable<string> Errors { get; set; }

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
