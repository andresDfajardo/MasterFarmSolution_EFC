using System.ComponentModel.DataAnnotations;

namespace MasterFarmSolution.Entities
{
    public class Product
    {
        public int id { get; set; }
        [Required]
        public int productTypeId { get; set; }
        public ProductType productType { get; set; }
        [StringLength(50)]
        [Required]
        public string name { get; set; }
        [Required]
        public bool is_active { get; set; }
    }
}
