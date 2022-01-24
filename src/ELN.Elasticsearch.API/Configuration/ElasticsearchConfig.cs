using ELN.Elasticsearch.API.Indexes;
using Nest;
using System.Text.Json;

namespace ELN.Elasticsearch.API
{
    public static class ElasticsearchConfig
    {
        public static IServiceCollection AddElasticsearch(this IServiceCollection services, IConfiguration configuration)
        {
            var settings = new ConnectionSettings(new Uri(configuration.GetConnectionString("ElasticsearchCs")));

            var client = new ElasticClient(settings);

            services.AddSingleton<IElasticClient>(client);

            CreateIndexAsync(client);

            return services;
        }

        private static async Task CreateIndexAsync(IElasticClient client)
        {
            if (!(await client.Indices.ExistsAsync("people")).Exists)
            {
                //var createIndexResponse = await client.Indices.CreateAsync("people", index => index.Map<PeopleIndex>(x => x.AutoMap()));

                var createIndexResponse = await client.Indices.CreateAsync("people", index => index.Map<PeopleIndex>(x => x
                    .Properties(props => props
                        .Keyword(k => k
                            .Name(p => p.Id)
                            .Name(p => p.Email)
                            .Name(p => p.EyeColor)
                            .Name(p => p.Gender))
                        .Text(t => t
                            .Name(p => p.Name)
                            .Name(p => p.Balance)
                            .Name(p => p.Picture)
                            .Name(p => p.Company)
                            .Name(p => p.Phone)
                            .Name(p => p.Address)
                        )
                        .Boolean(b => b
                            .Name(p => p.IsActive)))
                ));

                var peopleList = JsonSerializer.Deserialize<List<PeopleIndex>>(File.ReadAllText("../../assets/people_JSON.json"), new System.Text.Json.JsonSerializerOptions { IgnoreNullValues = true, PropertyNameCaseInsensitive = true });

                var result = await client.IndexManyAsync(peopleList, "people");

                if (result.IsValid) { }
            }
        }

    }
}
