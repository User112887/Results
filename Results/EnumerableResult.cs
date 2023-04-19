namespace GhostBackendStarterPack.Results;

public class EnumerableResult<TDataModel, TErrorModel> : IEnumerableResult<TDataModel, TErrorModel> 
{

    /// <summary>
    /// Gets or sets Succeeded
    /// </summary>
    public bool Succeeded { get; set; }

    /// <summary>
    /// Gets or sets Data
    /// </summary>
    public IEnumerable<TDataModel> Data { get;set; }

    /// <summary>
    /// Gets or sets Errors
    /// </summary>
    public IEnumerable<TErrorModel> Errors { get;set; }

    /// <summary>
    /// Generates a Failed result
    /// </summary>
    /// <param name="errors">Erorrs that caused the fail</param>
    /// <returns>Fail result with default values for the data</returns>
    public static EnumerableResult<TDataModel, TErrorModel> Fail(IEnumerable<TErrorModel> errors)
    {
        return new EnumerableResult<TDataModel, TErrorModel>
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
    public static EnumerableResult<TDataModel, TErrorModel> Fail()
    {
        return new EnumerableResult<TDataModel, TErrorModel>
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
    public static EnumerableResult<TDataModel, TErrorModel> Fail(TErrorModel error)
    {
        return new EnumerableResult<TDataModel, TErrorModel>
        {
            Data = default,
            Errors = new List<TErrorModel> { error },
            Succeeded = false
        };
    }

    /// <summary>
    /// Generates a success result
    /// </summary>
    /// <param name="data">Data returned from action</param>
    /// <returns>A result with data equal to the data returned from action</returns>
    public static EnumerableResult<TDataModel, TErrorModel> Success(IEnumerable<TDataModel> data)
    {
        return new EnumerableResult<TDataModel, TErrorModel>
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
    public static EnumerableResult<TDataModel, TErrorModel> Success()
    {
        return new EnumerableResult<TDataModel, TErrorModel>
        {
            Data = default,
            Succeeded = true,
            Errors = null
        };
    }
}
