using ELN.Elasticsearch.API.Indexes;
using Nest;

namespace ELN.Elasticsearch.API.Services
{
    public class PeopleService : ElasticService<PeopleIndex>, IPeopleService
    {
        public PeopleService(IElasticClient elasticClient) : base(elasticClient)
        {
            IndexName = "people";
        }

        public override string IndexName { get; set; }

        public async Task<ICollection<PeopleIndex>> GetAllAsync()
        {
            var result = await SearchAllAsync();

            return result.ToList();
        }

        public async Task<PeopleIndex> GetByIdAsync(int id)
        {
            var result = await SearchByIdAsync(id);

            return result;
        }

        public async Task<ICollection<PeopleIndex>> GetByNameMatch(string name)
        {
            var query = new QueryContainerDescriptor<PeopleIndex>().Match(p => p.Field(f => f.Name).Query(name));
            var result = await SearchByQueryAsync(_ => query);

            return result.ToList();
        }

        public async Task<ICollection<PeopleIndex>> GetByNameMatchPhrase(string name)
        {
            var query = new QueryContainerDescriptor<PeopleIndex>().MatchPhrase(p => p.Field(f => f.Name).Query(name));
            var result = await SearchByQueryAsync(_ => query);

            return result.ToList();
        }

        public async Task<ICollection<PeopleIndex>> GetByEmailWithWildcard(string wildcard)
        {
            var query = new QueryContainerDescriptor<PeopleIndex>().Wildcard(w => w.Field(f => f.Email).Value(wildcard));
            var result = await SearchByQueryAsync(_ => query);

            return result.ToList();
        }

        public async Task<ICollection<PeopleIndex>> GetByAgeRange(int start, int end)
        {
            var query = new QueryContainerDescriptor<PeopleIndex>().Range(w => w.Field(f => f.Age).GreaterThanOrEquals(start).LessThanOrEquals(end));
            var result = await SearchByQueryAsync(_ => query);

            return result.ToList();
        }

        public async Task<ICollection<PeopleIndex>> GetByPhonePrefix(string prefix)
        {
            var query = new QueryContainerDescriptor<PeopleIndex>().MatchPhrasePrefix(w => w.Field(f => f.Phone).Query(prefix));
            var result = await SearchByQueryAsync(_ => query);

            return result.ToList();
        }

    }
}
