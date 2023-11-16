using System;
public interface IApiRequest<TPayload, TResult> : IReturn<TResult>
{
    TPayload? Payload { get; }
    string GetApiUrl();
}
