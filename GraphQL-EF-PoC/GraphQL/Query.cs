﻿using GraphQL_EF_PoC.Data;
using GraphQL_EF_PoC.Models;

namespace GraphQL_EF_PoC.GraphQL
{
    public class Query
    {
        [UseDbContext(typeof(AppDbContext))]
        [UseProjection]
        public IQueryable<Vehicle> GetVehicle([ScopedService]AppDbContext context)
        {
            return context.Vehicles;
        }

        [UseDbContext(typeof(AppDbContext))]
        [UseProjection]
        public IQueryable<VehicleModel> GetModels([ScopedService] AppDbContext context)
        {
            return context.Models;
        }

        [UseDbContext(typeof(AppDbContext))]
        [UseProjection]
        public IQueryable<VehicleBrand> GetBrands([ScopedService] AppDbContext context)
        {
            return context.Brands;
        }
    }
}
