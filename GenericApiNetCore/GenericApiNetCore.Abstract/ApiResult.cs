using System;
public class ApiResult<T> : IApiResult<T>
{
    public virtual bool IsSuccess { get; set; }
    public virtual T Result { get; set; }
    public virtual string? Message { get; set; }

    public ApiResult(bool IsSuccess = default, T Result = default, string? Message = default)
    {
        this.Message = Message;
        this.Result = Result;
        this.IsSuccess = IsSuccess;
    }
}
