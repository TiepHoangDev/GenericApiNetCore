using GenericApiNetCore.Samples.Entities;
using GenericApiNetCore.ServerLib;

namespace GenericApiNetCore.WebApi.Controllers
{
    [RouteGeneric(typeof(Client))]
    public class ClientController : GenericControllerBase<Client>
    {
        public ClientController(IRepositoryMethods<Client> repositoryMethods) : base(repositoryMethods)
        {
        }

    }
}
