using GraphQL_EF_PoC.Data;

namespace GraphQL_EF_PoC.GraphQL
{
    public class Query
    {
        [UseDbContext(typeof(AppDbContext))]
        public IQueryable<Vehicle> GetVehicle([ScopedService]AppDbContext context)
        {
            return context.Vehicles;
        }
    }
}
