using MasterFarmSolution.Entities;
using Microsoft.EntityFrameworkCore;

namespace MasterFarmSolution.Repositories
{
    public interface IProductTypeRepository
    {
        Task<ProductType> CreateProductType(string productType);
        Task<List<ProductType>> GetAll();
        Task<ProductType> UpdateProductType(ProductType productType);
        Task<ProductType> GetProductType(int id);
        Task<ProductType> DeleteProductType(ProductType productType);
    }
    public class ProductTypeRepository : IProductTypeRepository
    {
        private readonly ApplicationDbContext _db;
        public ProductTypeRepository(ApplicationDbContext db)
        {
            _db = db;
        }
        public async Task<ProductType> CreateProductType(string productType)
        {
            ProductType newProductType = new ProductType
            {
                productType = productType,
                is_active = true
            };
            await _db.ProductTypes.AddAsync(newProductType);
            _db.SaveChanges();
            return newProductType;
        }

        public async Task<ProductType> DeleteProductType(ProductType productType)
        {
            productType.is_active = false;
            _db.ProductTypes.Update(productType);
            await _db.SaveChangesAsync();
            return productType;
        }

        public async Task<List<ProductType>> GetAll()
        {
            return await _db.ProductTypes.ToListAsync();
        }

        public async Task<ProductType> GetProductType(int id)
        {
            return await _db.ProductTypes.FirstOrDefaultAsync(p => p.id == id);
        }

        public async Task<ProductType> UpdateProductType(ProductType productType)
        {
            _db.ProductTypes.Update(productType);
            await _db.SaveChangesAsync();
            return productType;
        }
    }
}
