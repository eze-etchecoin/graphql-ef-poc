using System.ComponentModel.DataAnnotations;

namespace GraphQL_EF_PoC.Models;

public class VehicleBrand : BaseEntity
{
    public VehicleBrand()
    {
        Name = "";
    }
    
    [Required]
    public string Name { get; set; }

    public ICollection<VehicleModel> Models { get; set; }
}
