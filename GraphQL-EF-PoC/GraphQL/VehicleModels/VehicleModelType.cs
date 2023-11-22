using GraphQL_EF_PoC.Data;
using GraphQL_EF_PoC.Models;

namespace GraphQL_EF_PoC.GraphQL.VehicleModels
{
    public class VehicleModelType : ObjectType<VehicleModel>
    {
        protected override void Configure(IObjectTypeDescriptor<VehicleModel> descriptor)
        {
            descriptor.Description("Represents a vehicle model.");

            descriptor
                .Field(m => m.Id)
                .Description("The id of the model.");

            descriptor
                .Field(m => m.Name)
                .Description("The name of the model.");

            descriptor
                .Field(m => m.Brand)
                .ResolveWith<Resolvers>(r => r.GetBrand(default!, default!))
                .UseDbContext<AppDbContext>()
                .Description("The brand of the model.");
        }

        private class Resolvers
        {
            public VehicleBrand? GetBrand(VehicleModel model, [ScopedService] AppDbContext context)
            {
                return context.Brands.FirstOrDefault(b => b.Id == model.Brand.Id);
            }
        }
    }
}
