using System;
using System.Collections.Generic;
using System.Threading.Tasks;

public interface IApiMethods<T>
{
    Task<IApiResult<List<T>>> PagingAsync(PagingRequest<T> pageRequest);
    Task<IApiResult<List<T>>> CreateAsync(CreateRequest<T> entitysRequest);
    Task<IApiResult<List<T>>> UpdateAsync(UpdateRequest<T> entitysRequest);
    Task<IApiResult<int>> DeleteAsync(DeleteRequest<T> idsRequest);
}
