using System.ComponentModel.DataAnnotations;

namespace MasterFarmSolution.Entities
{
    public class User
    {
        public int id { get; set; }
        [StringLength(50)]
        [Required]
        public string userName { get; set; }
        [StringLength(50)]
        [Required]
        public string password { get; set; }
        [Required]
        public int farmerId { get; set; }
        public Farmer farmer { get; set; }
        [Required]
        public bool is_active { get; set; }
    }
}
