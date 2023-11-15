using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericApiNetCore.ServerLib
{
    [ApiController]
    [Route("[controller]")]
    public abstract class GenericControllerBase<T> : ControllerBase, IApiMethods<T>
    {
        private IRepositoryMethods<T> _repositoryMethods;

        public GenericControllerBase(IRepositoryMethods<T> repositoryMethods)
        {
            this._repositoryMethods = repositoryMethods;
        }

        [HttpPost("create")]
        public Task<IApiResult<List<T>>> CreateAsync(IApiRequest<List<T>, List<T>> entitysRequest)
        {
            return ApiResultFactory.FromTryMethodAsync(() => _repositoryMethods.CreateAsync(entitysRequest.Payload));
        }

        [HttpPost("delete")]
        public Task<IApiResult<int>> DeleteAsync(IApiRequest<Guid[], int> idsRequest)
        {
            return ApiResultFactory.FromTryMethodAsync(() => _repositoryMethods.DeleteAsync(idsRequest.Payload));
        }

        [HttpPost("paging")]
        public Task<IApiResult<List<T>>> PagingAsync(IApiRequest<int, List<T>> pageRequest)
        {
            return ApiResultFactory.FromTryMethodAsync(() => _repositoryMethods.PagingAsync(pageRequest.Payload));
        }

        [HttpPost("update")]
        public Task<IApiResult<List<T>>> UpdateAsync(IApiRequest<List<T>, List<T>> entitysRequest)
        {
            return ApiResultFactory.FromTryMethodAsync(() => _repositoryMethods.UpdateAsync(entitysRequest.Payload));
        }
    }
}
