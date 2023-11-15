using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GenericApiNetCore.ClientLib
{
    public class ClientApiMethod<T> : IApiMethods<T>
    {
        public HttpClientWrapper HttpClientWrapper { get; set; }
        public ClientApiMethod(HttpClientWrapper? httpClientWrapper = null)
        {
            HttpClientWrapper = httpClientWrapper ?? new HttpClientWrapper();
        }

        public Task<IApiResult<List<T>>> CreateAsync(IApiRequest<List<T>, List<T>> entitysRequest)
            => HttpClientWrapper.ExecuteAsync(entitysRequest);

        public Task<IApiResult<int>> DeleteAsync(IApiRequest<Guid[], int> idsRequest)
            => HttpClientWrapper.ExecuteAsync(idsRequest);


        public Task<IApiResult<List<T>>> PagingAsync(IApiRequest<int, List<T>> pageRequest)
            => HttpClientWrapper.ExecuteAsync(pageRequest);


        public Task<IApiResult<List<T>>> UpdateAsync(IApiRequest<List<T>, List<T>> entitysRequest)
            => HttpClientWrapper.ExecuteAsync(entitysRequest);

    }
}
