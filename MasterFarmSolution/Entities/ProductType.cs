using System.ComponentModel.DataAnnotations;

namespace MasterFarmSolution.Entities
{
    public class ProductType
    {
        public int id { get; set; }
        [StringLength(50)]
        [Required]
        public string productType { get; set; }
        [Required]
        public bool is_active { get; set; }
    }
}
