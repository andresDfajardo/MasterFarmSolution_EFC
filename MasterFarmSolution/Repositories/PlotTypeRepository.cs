using MasterFarmSolution.Entities;
using Microsoft.EntityFrameworkCore;

namespace MasterFarmSolution.Repositories
{
    public interface IPlotTypeRepository
    {
        Task<PlotType> CreatePlotType(string plotType);
        Task<List<PlotType>> GetAll();
        Task<PlotType> UpdatePlotType(PlotType plotType);
        Task<PlotType> GetPlotType(int id);
        Task<PlotType> DeletePlotType(PlotType plotType);
    }
    public class PlotTypeRepository : IPlotTypeRepository
    {
        private readonly ApplicationDbContext _db;
        public PlotTypeRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<PlotType> CreatePlotType(string plotType)
        {
            PlotType newPlotType = new PlotType
            {
                plotType = plotType,
                is_active = true
            };
            await _db.PlotTypes.AddAsync(newPlotType);
            _db.SaveChanges();
            return newPlotType;
        }

        public  async Task<PlotType> DeletePlotType(PlotType plotType)
        {
            plotType.is_active = false;
            _db.PlotTypes.Update(plotType);
            await _db.SaveChangesAsync();
            return plotType;
        }

        public async Task<List<PlotType>> GetAll()
        {
            return await _db.PlotTypes.ToListAsync();
        }

        public async Task<PlotType> GetPlotType(int id)
        {
            return await _db.PlotTypes.FirstOrDefaultAsync(p => p.id == id);
        }

        public async Task<PlotType> UpdatePlotType(PlotType plotType)
        {
            _db.PlotTypes.Update(plotType);
            await _db.SaveChangesAsync();
            return plotType;
        }
    }
}
