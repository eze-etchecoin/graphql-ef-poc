using GraphQL_EF_PoC.Models;

namespace GraphQL_EF_PoC.GraphQL
{
    public class Subscription
    {
        [Subscribe]
        [Topic]
        public Vehicle OnVehicleAdded([EventMessage] Vehicle vehicle) => vehicle;

        [Subscribe]
        [Topic]
        public VehicleBrand OnVehicleBrandAdded([EventMessage] VehicleBrand vehicleBrand) => vehicleBrand;

        [Subscribe]
        [Topic]
        public VehicleModel OnVehicleModelAdded([EventMessage] VehicleModel vehicleModel) => vehicleModel;
    }
}
