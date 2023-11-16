public class CreateRequest<T> : ApiRequest<List<T>, List<T>>
{
    public const string UrlTemplate = "create";
    
    public override string GetApiUrl() => $"{ApiInfoRequestAttribute.GetTemplate<T>()}/{UrlTemplate}";
}
