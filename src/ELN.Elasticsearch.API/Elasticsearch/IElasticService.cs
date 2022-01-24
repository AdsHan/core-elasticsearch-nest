using Nest;

namespace ELN.Elasticsearch.API
{
    public interface IElasticService<T> where T : class
    {
        Task<IEnumerable<T>> SearchAllAsync();
        Task<T> SearchByIdAsync(int id);
        Task<IEnumerable<T>> SearchByQueryAsync(Func<QueryContainerDescriptor<T>, QueryContainer> request);
    }
}
