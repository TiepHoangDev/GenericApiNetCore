using System;
public class ApiResult<T> : IApiResult<T>
{
    public virtual bool IsSuccess { get; set; } = false;
    public virtual T? Result { get; set; } = default;
    public virtual string? Message { get; set; } = default;
}
