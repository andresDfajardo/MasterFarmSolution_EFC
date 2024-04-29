using MasterFarmSolution.Entities;
using MasterFarmSolution.Repositories;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace MasterFarmSolution.Services
{
    public interface IProductService
    {
        Task<Product> CreateProduct(int productTypeId, string name);
        Task<List<Product>> GetAll();
        Task<Product> UpdateProduct(int id, int? productTypeId = null, string? name = null);
        Task<Product> GetProduct(int id);
        Task<Product> DeleteProduct(int id);
    }
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        public async Task<Product> CreateProduct(int productTypeId, string name)
        {
            return await _productRepository.CreateProduct(productTypeId, name);
        }

        public async Task<Product> DeleteProduct(int id)
        {
            Product desactiveProduct = await _productRepository.GetProduct(id);

            if (desactiveProduct != null)
            {
                desactiveProduct.is_active = false;
                return await _productRepository.DeleteProduct(desactiveProduct);
            }
            else
            {
                throw new Exception("Product not found");
            }
        }

        public async Task<List<Product>> GetAll()
        {
            return await _productRepository.GetAll();
        }

        public async Task<Product> GetProduct(int id)
        {
            return await _productRepository.GetProduct(id);
        }

        public async Task<Product> UpdateProduct(int id, int? productTypeId = null, string? name = null)
        {
            Product newProduct = await _productRepository.GetProduct(id);

            if (newProduct != null)
            {
                if (productTypeId != null)
                {
                    newProduct.productTypeId = (int)productTypeId;
                }
                else if (name != null)
                {
                    newProduct.name = name;
                }
                return await _productRepository.UpdateProduct(newProduct);
            }
            else
                return null;
        }
    }
}
