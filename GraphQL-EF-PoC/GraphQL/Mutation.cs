using GraphQL_EF_PoC.Data;
using GraphQL_EF_PoC.GraphQL.VehicleBrands;
using GraphQL_EF_PoC.GraphQL.VehicleModels;
using GraphQL_EF_PoC.GraphQL.Vehicles;
using GraphQL_EF_PoC.Models;
using HotChocolate.Subscriptions;

namespace GraphQL_EF_PoC.GraphQL
{
    public class Mutation
    {
        [UseDbContext(typeof(AppDbContext))]
        public async Task<AddVehiclePayload> AddVehicleAsync(
            AddVehicleInput input,
            [ScopedService] AppDbContext context,
            [Service] ITopicEventSender eventSender,
            CancellationToken cancellationToken)
        {
            var vehicleModel = await context.Models.FindAsync(input.ModelId) ??
                throw new ArgumentException("Invalid model id");
            
            var vehicle = new Vehicle
            {
                Asset = input.Asset,
                Year = input.Year,
                Model = vehicleModel,
                Notes = input.Notes
            };

            context.Vehicles.Add(vehicle);
            await context.SaveChangesAsync();

            await eventSender.SendAsync(nameof(Subscription.OnVehicleAdded), vehicle, cancellationToken);

            return new AddVehiclePayload(vehicle);
        }

        [UseDbContext(typeof(AppDbContext))]
        public async Task<AddVehicleBrandPayload> AddVehicleBrandAsync(
            AddVehicleBrandInput input,
            [ScopedService] AppDbContext context,
            [Service] ITopicEventSender eventSender,
            CancellationToken cancellationToken)
        {
            var vehicleBrand = new VehicleBrand
            {
                Name = input.Name
            };

            context.Brands.Add(vehicleBrand);
            await context.SaveChangesAsync();

            await eventSender.SendAsync(nameof(Subscription.OnVehicleBrandAdded), vehicleBrand, cancellationToken);

            return new AddVehicleBrandPayload(vehicleBrand);
        }

        [UseDbContext(typeof(AppDbContext))]
        public async Task<AddVehicleModelPayload> AddVehicleModelAsync(
            AddVehicleModelInput input,
            [ScopedService] AppDbContext context,
            [Service] ITopicEventSender eventSender,
            CancellationToken cancellationToken)
        {
            var vehicleBrand = await context.Brands.FindAsync(input.BrandId) ??
                throw new ArgumentException("Invalid brand id");
            
            var vehicleModel = new VehicleModel
            {
                Name = input.Name,
                Brand = vehicleBrand
            };

            context.Models.Add(vehicleModel);
            await context.SaveChangesAsync();

            await eventSender.SendAsync(nameof(Subscription.OnVehicleModelAdded), vehicleModel, cancellationToken);

            return new AddVehicleModelPayload(vehicleModel);
        }
    }
}
