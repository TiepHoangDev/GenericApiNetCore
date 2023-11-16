using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GenericApiNetCore.ClientLib
{
    public class ClientApiMethod<T> : IApiMethods<T>, IDisposable
    {
        public HttpClientWrapper HttpClientWrapper { get; set; }

        private readonly Uri _baseAddress;

        public ClientApiMethod(Uri baseAddress, HttpClientWrapper? httpClientWrapper = null)
        {
            HttpClientWrapper = httpClientWrapper ?? new HttpClientWrapper();
            _baseAddress = baseAddress;
        }
       
        public void Dispose()
        {
            HttpClientWrapper?.Dispose();
        }

        public Task<IApiResult<List<T>>> PagingAsync(PagingRequest<T> pageRequest)
        {
            return HttpClientWrapper.ExecuteAsync(pageRequest, _baseAddress);
        }

        public Task<IApiResult<List<T>>> CreateAsync(CreateRequest<T> entitysRequest)
        {
            return HttpClientWrapper.ExecuteAsync(entitysRequest, _baseAddress);
        }

        public Task<IApiResult<List<T>>> UpdateAsync(UpdateRequest<T> entitysRequest)
        {
            return HttpClientWrapper.ExecuteAsync(entitysRequest, _baseAddress);
        }

        public Task<IApiResult<int>> DeleteAsync(DeleteRequest<T> idsRequest)
        {
            return HttpClientWrapper.ExecuteAsync(idsRequest, _baseAddress);
        }
    }
}
