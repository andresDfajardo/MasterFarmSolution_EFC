using System.ComponentModel.DataAnnotations;

namespace MasterFarmSolution.Entities
{
    public class HarvestRecord
    {
        public int id { get; set; }
        [Required]
        public int operationId { get; set; }
        public AgriculturalOperation operation { get; set; }
        [Required]
        public int productId { get; set; }
        public Product product { get; set; }
        [Required]
        public int quantity { get; set; }
        [Required]
        public bool is_active { get; set; }
    }
}
