namespace PortfolioApi.Services;

// note:
//  not sure what description is for, but Error seems lonely, so we'll just leave it at that
//  oh...
//  Error = general error message
//  Description = a more detailed message about the error
public class ProducesEntity<T>
{
    protected ProducesEntity()
    {
    }

    public T? Entity { get; set; }
    public int StatusCode { get; set; }
    public string? Error { get; set; }
    public string? Description { get; set; }

    public bool Success
    {
        get => Entity is not null || EqualityComparer<T>.Default.Equals(Entity, default) is false;
    }
}

public class ProducesEntityGood<T> : ProducesEntity<T>
{
    public ProducesEntityGood(T value) : this(value, StatusCodes.Status200OK)
    {
    }

    public ProducesEntityGood(T value, int statusCode)
    {
        Entity = value;
        StatusCode = statusCode;
    }
}

public class ProducesEntityFail<T>: ProducesEntity<T>
{
    public ProducesEntityFail(int statusCode) : this(statusCode, "Unknown Error")
    {
    }

    public ProducesEntityFail(int statusCode, string error) : this(statusCode, error, "Unable to generate an exact error message")
    {
    }

    public ProducesEntityFail(int statusCode, string error, string description)
    {
        Entity = default;
        StatusCode = statusCode;
        Error = error;
        Description = description;
    }
}