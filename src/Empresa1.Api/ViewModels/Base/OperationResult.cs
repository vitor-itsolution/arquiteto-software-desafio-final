namespace Empresa1.Api.ViewModels.Base;

public class OperationResult<T>
{
    public bool Success { get; init; }
    public string? Error { get; init; }
    public T? Data { get; init; }
    public int StatusCode { get; init; }

    public static OperationResult<T> Ok(T data, int statusCode = StatusCodes.Status200OK) => new() { Success = true, Data = data,  StatusCode = statusCode };
    public static OperationResult<T> Fail(string error, int statusCode = StatusCodes.Status400BadRequest) => new() { Success = false, Error = error, StatusCode = statusCode };
}
