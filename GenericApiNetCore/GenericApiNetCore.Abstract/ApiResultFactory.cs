using System;
using System.Threading.Tasks;

/// <summary>
/// create instance for IApiResult<T>
/// </summary>
public class ApiResultFactory
{
    public static IApiResult<T> FromSucess<T>(T data) => new ApiResult<T>()
    {
        IsSuccess = true,
        Result = data,
        Message = default
    };

    public static IApiResult<T> FromFail<T>(string message) => new ApiResult<T>()
    {
        IsSuccess = false,
        Result = default,
        Message = message
    };

    public static IApiResult<T> FromException<T>(Exception ex)
        => FromFail<T>(ex.Message);

    public static async Task<IApiResult<T>> FromMethodAsync<T>(Func<Task<T>> getData)
    {
        var data = await getData.Invoke();
        return FromSucess(data);
    }

    public static async Task<IApiResult<T>> FromTryMethodAsync<T>(Func<Task<T>> getData)
    {
        try
        {
            return await FromMethodAsync(getData);
        }
        catch (Exception ex)
        {
            return FromException<T>(ex);
        }
    }
}
