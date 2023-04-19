namespace GhostBackendStarterPack.Results;

/// <summary>
/// Abstraction of Results
/// </summary>
/// <typeparam name="TDataModel">Type of data returned</typeparam>
/// <typeparam name="TErrorModel">Type of the errors that can be had</typeparam>
public interface IResult<TDataModel, TErrorModel>
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
    IEnumerable<TErrorModel> Errors { get; set; }
}
