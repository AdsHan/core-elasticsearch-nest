using ELN.Elasticsearch.API.Indexes;

namespace ELN.Elasticsearch.API.Services
{
    public interface IPeopleService : IElasticService<PeopleIndex>
    {
        Task<ICollection<PeopleIndex>> GetAllAsync();
        Task<PeopleIndex> GetByIdAsync(int id);
        Task<ICollection<PeopleIndex>> GetByNameMatch(string name);
        Task<ICollection<PeopleIndex>> GetByNameMatchPhrase(string name);
        Task<ICollection<PeopleIndex>> GetByEmailWithWildcard(string wildcard);
        Task<ICollection<PeopleIndex>> GetByAgeRange(int start, int end);
        Task<ICollection<PeopleIndex>> GetByPhonePrefix(string prefix);
    }
}
