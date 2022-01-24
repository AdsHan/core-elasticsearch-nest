using ELN.Elasticsearch.API.Indexes;
using Nest;

namespace ELN.Elasticsearch.API
{
    public abstract class ElasticService<T> : IElasticService<T> where T : BaseIndex
    {
        private readonly IElasticClient _elasticClient;

        public abstract string IndexName { get; set; }

        protected ElasticService(IElasticClient elasticClient)
        {
            _elasticClient = elasticClient;
        }

        public async Task<IEnumerable<T>> SearchAllAsync()
        {
            var search = new SearchDescriptor<T>(IndexName).MatchAll();
            var response = await _elasticClient.SearchAsync<T>(search);

            if (!response.IsValid) return null;

            return response.Hits.Select(hit => hit.Source).ToList();
        }

        public async Task<T> SearchByIdAsync(int id)
        {
            var response = await _elasticClient.GetAsync(DocumentPath<T>.Id(id).Index(IndexName));

            if (!response.IsValid) return null;

            return response.Source;
        }

        public async Task<IEnumerable<T>> SearchByQueryAsync(Func<QueryContainerDescriptor<T>, QueryContainer> request)
        {
            var response = await _elasticClient.SearchAsync<T>(s => s.Index(IndexName).Query(request));

            if (!response.IsValid) return null;

            return response.Hits.Select(hit => hit.Source).ToList();
        }

    }
}
