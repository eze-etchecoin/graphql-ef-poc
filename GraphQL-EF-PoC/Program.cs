using GraphQL.Server.Ui.Voyager;
using GraphQL_EF_PoC.Data;
using GraphQL_EF_PoC.GraphQL;
using GraphQL_EF_PoC.GraphQL.Vehicles;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddPooledDbContextFactory<AppDbContext>(opt =>
{
    opt.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Services
    .AddGraphQLServer()
    .AddQueryType<Query>()
    .AddType<VehicleType>()
    .AddType<VehicleBrandType>()
    .AddType<VehicleModelType>()
    .AddProjections()
    .AddFiltering()
    .AddSorting();

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.MapGraphQL();
app.UseGraphQLVoyager("/graphql-voyager",
    options: new VoyagerOptions()
{
    GraphQLEndPoint = "/graphql"
});

app.Run();
