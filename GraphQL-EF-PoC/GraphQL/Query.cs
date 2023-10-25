using GraphQL_EF_PoC.Data;

namespace GraphQL_EF_PoC.GraphQL
{
    public class Query
    {
        public IQueryable<Vehicle> GetVehicle([Service]AppDbContext context)
        {
            return context.Vehicles;
        }
    }
}
