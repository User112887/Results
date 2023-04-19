namespace GhostBackendStarterPack.Results;

/// <summary>
/// Abstraction of default results, errors are strings
/// </summary>
/// <typeparam name="TDataModel">Type of data results is</typeparam>
public interface IDefaultResult<TDataModel>
{
    /// <summary>
    /// Was the request succeesfull
    /// </summary>
    bool Succeeded { get; set; }

    /// <summary>
    /// Success Result
    /// </summary>
    TDataModel Data { get; set; }

    /// <summary>
    /// Erros if any
    /// </summary>
    IEnumerable<string> Errors { get; set; }
}