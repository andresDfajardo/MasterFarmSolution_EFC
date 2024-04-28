using System.ComponentModel.DataAnnotations;

namespace MasterFarmSolution.Entities
{
    public class Plot
    {
        public int id { get; set; }
        [StringLength(50)]
        [Required]
        public string number { get; set; }
        [Required]
        public int farmId { get; set; }
        public Farm farm { get; set; }
        [Required]
        public int plotTypeId { get; set; }
        public PlotType plotType { get; set; }
        [Required]
        public bool is_active { get; set; }
    }
}
