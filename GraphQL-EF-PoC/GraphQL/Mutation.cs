using GraphQL_EF_PoC.Data;
using GraphQL_EF_PoC.GraphQL.Vehicles;

namespace GraphQL_EF_PoC.GraphQL
{
    public class Mutation
    {
        [UseDbContext(typeof(AppDbContext))]
        public async Task<AddVehiclePayload> AddVehicleAsync(
            AddVehicleInput input,
            [ScopedService] AppDbContext context)
        {
            var vehicle = new Vehicle
            {
                Asset = input.Asset,
                Year = input.Year,
                Model = await context.Models.FindAsync(input.ModelId),
                Notes = input.Notes
            };

            context.Vehicles.Add(vehicle);
            await context.SaveChangesAsync();

            //await eventSender.SendAsync(nameof(Subscription.OnVehicleAdded), vehicle, cancellationToken);

            return new AddVehiclePayload(vehicle);
        }
    }
}
