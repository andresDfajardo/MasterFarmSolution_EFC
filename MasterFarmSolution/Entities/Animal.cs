using System.ComponentModel.DataAnnotations;

namespace MasterFarmSolution.Entities
{
    public class Animal
    {
        public int id { get; set; }
        [StringLength(50)]
        [Required]
        public string nameAnimal { get; set; }
        [Required]
        public int plotId { get; set; }
        public Plot plot { get; set; }
        [Required]
        public bool is_active { get; set; }
    }
}
