namespace GhostBackendStarterPack.Results;

/// <summary>
/// Implementation of IResult
/// </summary>
/// <typeparam name="TData">Data to be returned when no erros</typeparam>
/// <typeparam name="TErorrModel">Type of error to returned when errors are present</typeparam>
public class Result<TData, TErorrModel> : IResult<TData, TErorrModel>
{

    /// <summary>
    /// Was the request successful
    /// </summary>
    public bool Succeeded { get; set; }

    /// <summary>
    /// Data returened in case it was successful
    /// </summary>
    public TData Data { get; set; }

    /// <summary>
    /// Errors in case we have errors
    /// </summary>
    public IEnumerable<TErorrModel> Errors { get; set; }

    /// <summary>
    /// Generates a Failed result
    /// </summary>
    /// <param name="errors">Erorrs that caused the fail</param>
    /// <returns>Fail result with default values for the data</returns>
    public static Result<TData, TErorrModel> Fail(IEnumerable<TErorrModel> errors)
    {
        return new Result<TData, TErorrModel>
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
    public static Result<TData, TErorrModel> Fail()
    {
        return new Result<TData, TErorrModel>
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
    public static Result<TData, TErorrModel> Fail(TErorrModel error)
    {
        return new Result<TData, TErorrModel>
        {
            Data = default,
            Errors = new List<TErorrModel> { error },
            Succeeded = false
        };
    }

    /// <summary>
    /// Generates a success result
    /// </summary>
    /// <param name="data">Data returned from action</param>
    /// <returns>A result with data equal to the data returned from action</returns>
    public static Result<TData, TErorrModel> Success(TData data)
    {
        return new Result<TData, TErorrModel>
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
    public static Result<TData, TErorrModel> Success()
    {
        return new Result<TData, TErorrModel>
        {
            Data = default,
            Succeeded = true,
            Errors = null
        };
    }
}
