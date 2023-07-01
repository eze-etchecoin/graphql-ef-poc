using System.ComponentModel.DataAnnotations;

namespace GraphQL_EF_PoC.Models;

public class VehicleModel : BaseEntity
{
    [Required]
    public string Name { get; set; }
    
    [Required]
    public VehicleBrand Brand { get; set; }
}
