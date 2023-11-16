public class UpdateRequest<T> : ApiRequest<List<T>, List<T>>
{
    public const string UrlTemplate = "update";
    
    public override string GetApiUrl() => $"{ApiInfoRequestAttribute.GetTemplate<T>()}/{UrlTemplate}";
}
