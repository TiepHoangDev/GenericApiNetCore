using GenericApiNetCore.Samples.Entities;
using GenericApiNetCore.ServerLib;
using Microsoft.AspNetCore.Mvc;

namespace GenericApiNetCore.WebApi.Controllers
{
    [RouteGeneric(typeof(Product))]
    public class ProductController : GenericControllerBase<Product>
    {
        public ProductController(IRepositoryMethods<Product> repositoryMethods) : base(repositoryMethods)
        {
        }

    }
}
