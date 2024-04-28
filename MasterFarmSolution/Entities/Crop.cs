using System.ComponentModel.DataAnnotations;

namespace MasterFarmSolution.Entities
{
    public class Crop
    {
        public int id { get; set; }
        [StringLength(50)]
        [Required]
        public string name { get; set; }
        [StringLength(50)]
        [Required]
        public string description { get; set; }
        [StringLength(3)]
        [Required]
        public string harvestDays { get; set; }
        [Required]
        public int plotId { get; set; }
        public Plot plot { get; set; }
        [Required]
        public bool is_active { get; set; }
    }
}
