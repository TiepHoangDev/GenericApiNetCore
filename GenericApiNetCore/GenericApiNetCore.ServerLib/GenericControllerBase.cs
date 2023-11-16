using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Routing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericApiNetCore.ServerLib
{
    [ApiController]
    public abstract class GenericControllerBase<T> : ControllerBase, IApiMethods<T>
    {
        private IRepositoryMethods<T> _repositoryMethods;

        public GenericControllerBase(IRepositoryMethods<T> repositoryMethods)
        {
            this._repositoryMethods = repositoryMethods;
        }

        [HttpPost(CreateRequest<T>.UrlTemplate)]
        public virtual Task<IApiResult<List<T>>> CreateAsync([FromBody] CreateRequest<T> entitysRequest)
        {
            return ApiResultFactory.FromTryMethodAsync(async () => await _repositoryMethods.CreateAsync(entitysRequest.Payload));
        }

        [HttpPost(DeleteRequest<T>.UrlTemplate), HttpDelete]
        public virtual Task<IApiResult<int>> DeleteAsync([FromBody] DeleteRequest<T> idsRequest)
        {
            return ApiResultFactory.FromTryMethodAsync(async () => await _repositoryMethods.DeleteAsync(idsRequest.Payload));
        }

        [HttpPost(PagingRequest<T>.UrlTemplate), HttpGet]
        public virtual Task<IApiResult<List<T>>> PagingAsync([FromBody] PagingRequest<T> pageRequest)
        {
            return ApiResultFactory.FromTryMethodAsync(async () => await _repositoryMethods.PagingAsync(pageRequest.Payload));
        }

        [HttpPost(UpdateRequest<T>.UrlTemplate), HttpPut]
        public virtual Task<IApiResult<List<T>>> UpdateAsync([FromBody] UpdateRequest<T> entitysRequest)
        {
            return ApiResultFactory.FromTryMethodAsync(async () => await _repositoryMethods.UpdateAsync(entitysRequest.Payload));
        }
    }
}
