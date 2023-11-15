using System;
using System.Collections.Generic;
using System.Threading.Tasks;
public interface IRepositoryMethods<T>
{
    Task<List<T>> PagingAsync(int pageRequest);
    Task<List<T>> CreateAsync(List<T> entitysRequest);
    Task<List<T>> UpdateAsync(List<T> entitysRequest);
    Task<int> DeleteAsync(Guid[] idsRequest);
}