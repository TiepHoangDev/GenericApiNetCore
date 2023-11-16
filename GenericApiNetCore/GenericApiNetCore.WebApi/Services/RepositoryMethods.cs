namespace GenericApiNetCore.WebApi.Services
{
    public abstract class RepositoryMethods<T> : IRepositoryMethods<T>
    {
        readonly List<T> entities = new List<T>();

        public async Task<List<T>> CreateAsync(List<T> entitysRequest)
        {
            entities.AddRange(entitysRequest);
            return entitysRequest;
        }

        public async Task<int> DeleteAsync(Guid[] idsRequest)
        {
            entities.RemoveAll(q => idsRequest.Contains(GetId(q)));
            return idsRequest.Length;
        }

        public abstract Guid GetId(T entity);

        public async Task<List<T>> PagingAsync(int pageRequest)
        {
            return entities.Skip((pageRequest - 1) * 5).Take(pageRequest * 5).ToList();
        }

        public async Task<List<T>> UpdateAsync(List<T> entitysRequest)
        {
            await DeleteAsync(entitysRequest.Select(q => GetId(q)).ToArray());
            await CreateAsync(entitysRequest);
            return entitysRequest;
        }
    }
}
