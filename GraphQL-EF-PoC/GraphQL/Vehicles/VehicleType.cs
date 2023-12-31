﻿using GraphQL_EF_PoC.Data;
using GraphQL_EF_PoC.Models;

namespace GraphQL_EF_PoC.GraphQL.Vehicles
{
    public class VehicleType : ObjectType<Vehicle>
    {
        protected override void Configure(IObjectTypeDescriptor<Vehicle> descriptor)
        {
            descriptor.Description("Represents a vehicle with its manufacturing data.");

            descriptor
                .Field(v => v.Id)
                .Description("The id of the vehicle.");

            descriptor
                .Field(v => v.Asset)
                .Description("The asset number of the vehicle.");

            descriptor
                .Field(v => v.Year)
                .Description("The year the vehicle was manufactured.");

            descriptor
                .Field(v => v.Model)
                    .Description("The model of the vehicle.");

            descriptor
                .Field(v => v.Notes)
                .Description("The notes for the vehicle.");

            descriptor
                .Field(v => v.Model)
                .ResolveWith<Resolvers>(v => v.GetModel(default!, default!))
                .UseDbContext<AppDbContext>()
                .Description("The model of the vehicle.");
        }

        private class Resolvers
        {
            public VehicleModel GetModel(Vehicle vehicle, [ScopedService] AppDbContext context)
            {
                return context.Models.FirstOrDefault(m => m.Id == vehicle.Model.Id);
            }
        }
    }
}
