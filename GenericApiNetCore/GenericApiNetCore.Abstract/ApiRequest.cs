using System;
public class ApiRequest<TPayload, TResult> : IApiRequest<TPayload, TResult>
{
    public ApiRequest(TPayload payload)
    {
        Payload = payload;
    }

    public TPayload Payload { get; set; }
}