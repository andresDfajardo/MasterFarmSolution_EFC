using MasterFarmSolution.Entities;
using MasterFarmSolution.Repositories;

namespace MasterFarmSolution.Services
{
    public interface IProductTypeService
    {
        Task<ProductType> CreateProductType(string productType);
        Task<List<ProductType>> GetAll();
        Task<ProductType> UpdateProductType(int id, string? productType = null);
        Task<ProductType> GetProductType(int id);
        Task<ProductType> DeleteProductType(int id);
    }
    public class ProductTypeService : IProductTypeService
    {
        private readonly IProductTypeRepository _productTypeRepository;
        public ProductTypeService(IProductTypeRepository productTypeRepository)
        {
            _productTypeRepository = productTypeRepository;
        }
        public async Task<ProductType> CreateProductType(string productType)
        {
            return await _productTypeRepository.CreateProductType(productType);
        }

        public async Task<ProductType> DeleteProductType(int id)
        {
            ProductType desactiveProductType = await _productTypeRepository.GetProductType(id);

            if (desactiveProductType != null)
            {
                desactiveProductType.is_active = false;
                return await _productTypeRepository.DeleteProductType(desactiveProductType);
            }
            else
            {
                throw new Exception("Product Type not found");
            }
        }

        public async Task<List<ProductType>> GetAll()
        {
            return await _productTypeRepository.GetAll();
        }

        public async Task<ProductType> GetProductType(int id)
        {
            return await _productTypeRepository.GetProductType(id);
        }

        public async Task<ProductType> UpdateProductType(int id, string productType = null)
        {
            ProductType newProductType = await _productTypeRepository.GetProductType(id);

            if (newProductType != null)
            {
                if (productType != null)
                {
                    newProductType.productType = productType;
                }
                return await _productTypeRepository.UpdateProductType(newProductType);
            }
            else
                return null;
        }
    }
}
