using GraphQL.Server.Ui.Voyager;
using GraphQL_EF_PoC.Data;
using GraphQL_EF_PoC.GraphQL;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddPooledDbContextFactory<AppDbContext>(opt =>
{
    opt.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Services
    .AddGraphQLServer()
    .AddQueryType<Query>()
    .AddProjections();


var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.MapGraphQL();
app.UseGraphQLVoyager(options: new VoyagerOptions()
{
    GraphQLEndPoint = "/graphql"
});

app.Run();
