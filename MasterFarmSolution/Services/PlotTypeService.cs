using MasterFarmSolution.Entities;
using MasterFarmSolution.Repositories;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace MasterFarmSolution.Services
{
    public interface IPlotTypeService
    {
        Task<PlotType> CreatePlotType(string plotType);
        Task<List<PlotType>> GetAll();
        Task<PlotType> UpdatePlotType(int id, string? plotType = null);
        Task<PlotType> GetPlotType(int id);
        Task<PlotType> DeletePlotType(int id);
    }
    public class PlotTypeService : IPlotTypeService
    {
        private readonly IPlotTypeRepository _plotTypeRepository;
        public PlotTypeService(IPlotTypeRepository plotTypeRepository)
        {
            _plotTypeRepository = plotTypeRepository;
        }
        public async Task<PlotType> CreatePlotType(string plotType)
        {
            return await _plotTypeRepository.CreatePlotType(plotType);
        }

        public async Task<PlotType> DeletePlotType(int id)
        {
            PlotType desactivePlotType = await _plotTypeRepository.GetPlotType(id);

            if (desactivePlotType != null)
            {
                desactivePlotType.is_active = false;
                return await _plotTypeRepository.DeletePlotType(desactivePlotType);
            }
            else
            {
                throw new Exception("Plot Type not found");
            }
        }

        public async Task<List<PlotType>> GetAll()
        {
            return await _plotTypeRepository.GetAll();
        }

        public async Task<PlotType> GetPlotType(int id)
        {
            return await _plotTypeRepository.GetPlotType(id);
        }

        public async Task<PlotType> UpdatePlotType(int id, string plotType = null)
        {
            PlotType newPlotType = await _plotTypeRepository.GetPlotType(id);

            if (newPlotType != null)
            {
                if (plotType != null)
                {
                    newPlotType.plotType = plotType;
                }
                return await _plotTypeRepository.UpdatePlotType(newPlotType);
            }
            else
                return null;
        }
    }
}
