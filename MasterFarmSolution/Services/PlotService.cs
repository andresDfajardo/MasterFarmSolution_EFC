using MasterFarmSolution.Entities;
using MasterFarmSolution.Repositories;

namespace MasterFarmSolution.Services
{
    public interface IPlotService
    {
        Task<Plot> CreatePlot(string number, int farmId, int plotTypeId);
        Task<List<Plot>> GetAll();
        Task<Plot> UpdatePlot(int id, string? number = null, int? farmId = null, int? plotTypeId = null);
        Task<Plot> GetPlot(int id);
        Task<Plot> DeletePlot(int id);
    }
    public class PlotService : IPlotService
    {
        private readonly IPlotRepository _plotRepository;
        public PlotService(IPlotRepository plotRepository)
        {
            _plotRepository = plotRepository;
        }
        public async Task<Plot> CreatePlot(string number, int farmId, int plotTypeId)
        {
            return await _plotRepository.CreatePlot(number, farmId, plotTypeId);
        }

        public async Task<Plot> DeletePlot(int id)
        {
            Plot desactivePlot = await _plotRepository.GetPlot(id);

            if (desactivePlot != null)
            {
                desactivePlot.is_active = false;
                return await _plotRepository.DeletePlot(desactivePlot);
            }
            else
            {
                throw new Exception("Plot not found");
            }
        }

        public async Task<List<Plot>> GetAll()
        {
            return await _plotRepository.GetAll();
        }

        public async Task<Plot> GetPlot(int id)
        {
            return await _plotRepository.GetPlot(id);
        }

        public async Task<Plot> UpdatePlot(int id, string? number = null, int? farmId = null, int? plotTypeId = null)
        {
            Plot newPlot = await _plotRepository.GetPlot(id);

            if (newPlot != null)
            {
                if (number != null)
                {
                    newPlot.number = number;
                }else if (farmId != null)
                {
                    newPlot.farmId = (int)farmId;
                }else if (plotTypeId != null)
                {
                    newPlot.plotTypeId = (int)plotTypeId;
                }
                return await _plotRepository.UpdatePlot(newPlot);
            }
            else
                return null;
        }
    }
}
