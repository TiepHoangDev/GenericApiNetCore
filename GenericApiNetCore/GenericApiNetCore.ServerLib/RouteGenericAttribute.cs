using Microsoft.AspNetCore.Mvc;
using System.Reflection;

namespace GenericApiNetCore.ServerLib
{
    public class RouteGenericAttribute : RouteAttribute
    {
        public RouteGenericAttribute(Type type) : base(ApiInfoRequestAttribute.GetTemplate(type))
        {
        }
    }
}
