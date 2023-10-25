using System.ComponentModel.DataAnnotations;
using GraphQL_EF_PoC.Models;

namespace GraphQL_EF_PoC;

public class Vehicle : BaseEntity
{
    public Vehicle()
    {
        Asset = "";
        Model = new VehicleModel();
    }

    public string Asset { get; set; }

    public int Year { get; set; }

    [Required]
    public VehicleModel Model {get; set;}

    public string? Notes { get; set; }
}
