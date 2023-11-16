using System.Reflection;
/// <summary>
/// define ApiUrl for entity
/// </summary>
public class ApiInfoRequestAttribute : Attribute
{
    public ApiInfoRequestAttribute(string apiUrl)
    {
        this.ApiUrl = apiUrl;
    }
    public string ApiUrl { get; }

    #region Methods helper 

    public static string GetTemplate<T>() => GetTemplate(typeof(T));

    public static string GetTemplate(Type type)
    {
        return type.GetCustomAttribute<ApiInfoRequestAttribute>(true)?.ApiUrl ?? type.Name;
    }
    
    #endregion

}
