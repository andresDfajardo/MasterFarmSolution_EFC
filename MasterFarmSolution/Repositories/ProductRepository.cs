using MasterFarmSolution.Entities;
using Microsoft.EntityFrameworkCore;

namespace MasterFarmSolution.Repositories
{
    public interface IProductRepository
    {
        Task<Product> CreateProduct(int productTypeId, string name);
        Task<List<Product>> GetAll();
        Task<Product> UpdateProduct(Product product);
        Task<Product> GetProduct(int id);
        Task<Product> DeleteProduct(Product product);
    }
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationDbContext _db;
        public ProductRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<Product> CreateProduct(int productTypeId, string name)
        {
            Product newProduct = new Product
            {
                productTypeId = productTypeId,
                name = name,
                is_active = true
            };
            await _db.Products.AddAsync(newProduct);
            _db.SaveChanges();
            return newProduct;
        }

        public async Task<Product> DeleteProduct(Product product)
        {
            product.is_active = false;
            _db.Products.Update(product);
            await _db.SaveChangesAsync();
            return product;
        }

        public async Task<List<Product>> GetAll()
        {
            return await _db.Products.ToListAsync();
        }

        public async Task<Product> GetProduct(int id)
        {
            return await _db.Products.FirstOrDefaultAsync(p => p.id == id);
        }

        public async Task<Product> UpdateProduct(Product product)
        {
            _db.Products.Update(product);
            await _db.SaveChangesAsync();
            return product;
        }
    }
}
