using GraphQL_EF_PoC.Data;
using GraphQL_EF_PoC.Models;

namespace GraphQL_EF_PoC.GraphQL.VehicleBrands
{
    public class VehicleBrandType : ObjectType<VehicleBrand>
    {
        protected override void Configure(IObjectTypeDescriptor<VehicleBrand> descriptor)
        {
            descriptor.Description("Represents a vehicle brand.");

            descriptor
                .Field(p => p.Models)
                .ResolveWith<Resolvers>(p => p.GetModels(default!, default!))
                .UseDbContext<AppDbContext>()
                .Description("This is the list of models for this brand.");
        }

        private class Resolvers
        {
            public IQueryable<VehicleModel> GetModels(VehicleBrand brand, [ScopedService] AppDbContext context)
            {
                return context.Models.Where(m => m.Brand.Id == brand.Id);
            }
        }
    }
}
