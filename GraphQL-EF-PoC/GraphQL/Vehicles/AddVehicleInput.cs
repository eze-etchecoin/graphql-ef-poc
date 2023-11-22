namespace GraphQL_EF_PoC.GraphQL.Vehicles
{
    public record AddVehicleInput(
        string Asset,
        int Year,
        int ModelId,
        string Notes);
}
