using ELN.Elasticsearch.API;
using ELN.Elasticsearch.API.Configuration;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddApiConfiguration();
builder.Services.AddDependencyConfiguration(builder.Configuration);
builder.Services.AddElasticsearch(builder.Configuration);
builder.Services.AddSwaggerConfiguration();

var app = builder.Build();

app.UseApiConfiguration();
app.UseSwaggerConfiguration();

app.Run();
