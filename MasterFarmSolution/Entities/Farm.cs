using System.ComponentModel.DataAnnotations;

namespace MasterFarmSolution.Entities
{
    public class Farm
    {
        public int id { get; set; }
        [StringLength(50)]
        [Required]
        public string farmName { get; set; }
        [Required]
        public int farmerId { get; set; }
        public Farmer farmer { get; set; }
        [Required]
        public bool is_active { get; set; }
    }
}
