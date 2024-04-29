using MasterFarmSolution.Entities;
using Microsoft.EntityFrameworkCore;

namespace MasterFarmSolution.Repositories
{
    public interface IPlotRepository
    {
        Task<Plot> CreatePlot(string number, int farmId, int plotTypeId);
        Task<List<Plot>> GetAll();
        Task<Plot> UpdatePlot(Plot plot);
        Task<Plot> GetPlot(int id);
        Task<Plot> DeletePlot(Plot plot);
    }
    public class PlotRepository : IPlotRepository
    {
        private readonly ApplicationDbContext _db;
        public PlotRepository(ApplicationDbContext db)
        {
            _db = db;
        }
        public async Task<Plot> CreatePlot(string number, int farmId, int plotTypeId)
        {
            Plot newPlot = new Plot
            {
                number = number,
                farmId = farmId,
                plotTypeId = plotTypeId,
                is_active = true
            };
            await _db.Plots.AddAsync(newPlot);
            _db.SaveChanges();
            return newPlot;
        }

        public async Task<Plot> DeletePlot(Plot plot)
        {
            plot.is_active = false;
            _db.Plots.Update(plot);
            await _db.SaveChangesAsync();
            return plot;
        }

        public async Task<List<Plot>> GetAll()
        {
            return await _db.Plots.ToListAsync();
        }

        public async Task<Plot> GetPlot(int id)
        {
            return await _db.Plots.FirstOrDefaultAsync(p => p.id == id);
        }

        public async Task<Plot> UpdatePlot(Plot plot)
        {
            _db.Plots.Update(plot);
            await _db.SaveChangesAsync();
            return plot;
        }
    }
}
