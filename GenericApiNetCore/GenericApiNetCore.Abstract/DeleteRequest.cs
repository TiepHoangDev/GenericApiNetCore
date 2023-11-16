public class DeleteRequest<T> : ApiRequest<Guid[], int>
{
    public const string UrlTemplate = "delete";
    
    public override string GetApiUrl() => $"{ApiInfoRequestAttribute.GetTemplate<T>()}/{UrlTemplate}";
}