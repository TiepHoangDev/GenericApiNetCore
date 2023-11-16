public class PagingRequest<T> : ApiRequest<int, List<T>>
{
    public const string UrlTemplate = "paging";

    public override string GetApiUrl() => $"{ApiInfoRequestAttribute.GetTemplate<T>()}/{UrlTemplate}";
}
