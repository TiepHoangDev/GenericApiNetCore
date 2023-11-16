using GenericApiNetCore.Samples.Entities;

namespace GenericApiNetCore.WebApi.Services
{
    public class ClientRepositoryMethods : RepositoryMethods<Client>
    {
        public override Guid GetId(Client entity) => entity.Id;
    }
}
