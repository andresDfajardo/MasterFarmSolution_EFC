using System.ComponentModel.DataAnnotations;

namespace MasterFarmSolution.Entities
{
    public class PlotType
    {
        public int id { get; set; }
        [StringLength(50)]
        [Required]
        public string plotType { get; set; }
        [Required]
        public bool is_active { get; set; }
    }
}
