using System.ComponentModel.DataAnnotations;

namespace MasterFarmSolution.Entities
{
    public class Game
    {
        public int id { get; set; }
        [Required]
        public string dateLastConnection { get; set; }
        [Required]
        public bool is_active { get; set; }
    }
}
