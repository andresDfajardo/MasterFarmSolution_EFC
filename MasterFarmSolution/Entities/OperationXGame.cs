using System.ComponentModel.DataAnnotations;

namespace MasterFarmSolution.Entities
{
    public class OperationXGame
    {
        public int id { get; set; }

        [Required]
        public int agriculturalOperationId { get; set; }
        public AgriculturalOperation agriculturalOperation { get; set; }

        [Required]
        public int gameId { get; set; }
        public Game game { get; set; }

        [Required]
        public DateTime dateTimeOperationXGame { get; set; }

        [Required]
        public bool is_active { get; set; }
    }
}
