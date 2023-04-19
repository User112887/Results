namespace Results.Parameters;

/// <summary>
/// Paged parameters
/// </summary>
public class PagedParameters
{

    /// <summary>
    /// Gets or sets PageSize
    /// </summary>
    public int PageSize { get; set; }

    /// <summary>
    /// Gets or sets Page
    /// </summary>
    public int Page { get; set; }

    /// <summary>
    /// Default construcotr
    /// </summary>
    public PagedParameters() { }

    /// <summary>
    /// Constructor with parameters
    /// </summary>
    /// <param name="page">Parameter for page</param>
    /// <param name="pageSize">Parameter for pageSize</param>
    public PagedParameters(int page, int pageSize)
    {
        PageSize = pageSize;
        Page = page;
    }
}

