using GenericApiNetCore.Samples.Entities;

namespace GenericApiNetCore.WebApi.Services
{
    public class ProductRepositoryMethods : RepositoryMethods<Product>
    {
        public override Guid GetId(Product entity) => entity.Id;
    }
}
