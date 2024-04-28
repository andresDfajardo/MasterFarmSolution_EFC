using System.ComponentModel.DataAnnotations;

namespace MasterFarmSolution.Entities
{
    public class AgriculturalOperationsType
    {
        public int id { get; set; }
        [StringLength(50)]
        [Required]
        public string type { get; set; }
        [Required]
        public bool is_active { get; set; }
    }
}
