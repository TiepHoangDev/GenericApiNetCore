using System;
using System.Collections.Generic;
using System.Threading.Tasks;

public interface IApiMethods<T>
{
    Task<IApiResult<List<T>>> PagingAsync(IApiRequest<int, List<T>> pageRequest);
    Task<IApiResult<List<T>>> CreateAsync(IApiRequest<List<T>, List<T>> entitysRequest);
    Task<IApiResult<List<T>>> UpdateAsync(IApiRequest<List<T>, List<T>> entitysRequest);
    Task<IApiResult<int>> DeleteAsync(IApiRequest<Guid[], int> idsRequest);
}
