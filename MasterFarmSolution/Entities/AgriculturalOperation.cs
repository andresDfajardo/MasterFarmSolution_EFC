using System.ComponentModel.DataAnnotations;

namespace MasterFarmSolution.Entities
{
    public class AgriculturalOperation
    {
        public int id { get; set; }
        [Required]
        public int cropId { get; set; }
        public Crop Id { get; set; }
        [Required]
        public string dateOperation { get; set; }
        [Required]
        public int operationTypeId { get; set; }
        public AgriculturalOperationsType operationType { get; set; }
        [StringLength(100)]
        [Required]
        public string description { get; set; }
        [Required]
        public bool is_active { get; set; }
    }
}
