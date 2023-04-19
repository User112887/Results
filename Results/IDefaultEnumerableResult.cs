namespace GhostBackendStarterPack.Results;

public interface IDefaultEnumerableResult<TDataModel>
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
}
