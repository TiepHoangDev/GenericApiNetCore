using System;

public class ApiInfoRequestAtribute : Attribute
{
    public ApiInfoRequestAtribute(string apiUrl)
    {
        this.ApiUrl = apiUrl;
    }

    public string ApiUrl { get; }
}
