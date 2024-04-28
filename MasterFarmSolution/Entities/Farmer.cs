using System.ComponentModel.DataAnnotations;

namespace MasterFarmSolution.Entities
{
    public class Farmer
    {
        public int id { get; set; }
        [StringLength(50)]
        [Required]
        public string firstNameFarmer { get; set; }
        [StringLength(50)]
        [Required]
        public string lastNameFarmer { get; set; }
        [StringLength(50)]
        [Required]
        public string emailFarmer { get; set; }
        [StringLength(20)]
        [Required]
        public string phoneFarmer { get; set; }
        [StringLength(50)]
        [Required]
        public string addressFarmer { get; set; }
        [Required]
        public bool is_active { get; set; }
    }
}
