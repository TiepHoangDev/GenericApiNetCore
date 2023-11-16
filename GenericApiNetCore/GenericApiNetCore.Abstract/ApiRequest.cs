using System;
using System.Diagnostics;
using System.Reflection;

public abstract class ApiRequest<TPayload, TResult> : IApiRequest<TPayload, TResult>
{
    public virtual TPayload? Payload { get; set; }

    public virtual string GetApiUrl()
    {
        return ApiInfoRequestAttribute.GetTemplate<TPayload>()
                ?? ApiInfoRequestAttribute.GetTemplate(this.GetType())
                ?? this.GetType().Name;
    }
}
