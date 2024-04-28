using MasterFarmSolution.Entities;
using Microsoft.EntityFrameworkCore;

namespace MasterFarmSolution
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<AgriculturalOperation> AgriculturalOperations { get; set; }
        public DbSet<AgriculturalOperationsType> AgriculturalOperationsTypes { get; set; }
        public DbSet<Animal> Animals { get; set; }
        public DbSet<Crop> Crops { get; set; }
        public DbSet<Farmer> Farmers { get; set; }
        public DbSet<Farm> Farms { get; set; }
        public DbSet<Game> Games { get; set; }
        public DbSet<HarvestRecord> HarvestRecords { get; set; }
        public DbSet<OperationXGame> OperationXGames { get; set; }
        public DbSet<Plot> Plots { get; set; }
        public DbSet<PlotType> PlotTypes { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductType> ProductTypes { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
