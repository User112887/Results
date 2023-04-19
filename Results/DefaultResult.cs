namespace GhostBackendStarterPack.Results;

/// <summary>
/// Model for default results with string as default error model
/// </summary>
/// <typeparam name="TDataModel">Type of data the result returns</typeparam>
public class DefaultResult<TDataModel> : IDefaultResult<TDataModel>
{

    /// <summary>
    /// Gets or sets Succeeded 
    /// </summary>
    public bool Succeeded { get; set; }

    /// <summary>
    /// Gets or sets Data
    /// </summary>
    public TDataModel Data { get; set; }

    /// <summary>
    /// Gets or sets errors
    /// </summary>
    public IEnumerable<string> Errors { get; set; }

    /// <summary>
    /// Generates a Failed result
    /// </summary>
    /// <param name="errors">Erorrs that caused the fail</param>
    /// <returns>Fail result with default values for the data</returns>
    public static DefaultResult<TDataModel> Fail(IEnumerable<string> errors)
    {
        return new DefaultResult<TDataModel>
        {
            Data = default,
            Errors = errors,
            Succeeded = false
        };
    }

    /// <summary>
    /// Generates a failed result with no error message/messages
    /// </summary>
    /// <returns>Faled result with default values for data and errors</returns>
    public static DefaultResult<TDataModel> Fail()
    {
        return new DefaultResult<TDataModel>
        {
            Data = default,
            Errors = default,
            Succeeded = false
        };
    }

    /// <summary>
    /// Generates a Failed result
    /// </summary>
    /// <param name="error">The error that caused the fail</param>
    /// <returns>Fail result with default values for the data</returns>
    public static DefaultResult<TDataModel> Fail(string error)
    {
        return new DefaultResult<TDataModel>
        {
            Data = default,
            Errors = new List<string> { error },
            Succeeded = false
        };
    }

    /// <summary>
    /// Generates a success result
    /// </summary>
    /// <param name="data">Data returned from action</param>
    /// <returns>A result with data equal to the data returned from action</returns>
    public static DefaultResult<TDataModel> Success(TDataModel data)
    {
        return new DefaultResult<TDataModel>
        {
            Data = data,
            Succeeded = true,
            Errors = null
        };
    }

    /// <summary>
    /// Generates a success result with no data
    /// </summary>
    /// <returns>Success result</returns>
    public static DefaultResult<TDataModel> Success()
    {
        return new DefaultResult<TDataModel>
        {
            Data = default,
            Succeeded = true,
            Errors = null
        };
    }
}