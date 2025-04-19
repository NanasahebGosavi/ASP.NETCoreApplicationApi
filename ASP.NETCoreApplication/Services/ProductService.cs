using ASP.NETCoreApplication.Context;
using ASP.NETCoreApplication.Entities;
using ASP.NETCoreApplication.Interface;
using Microsoft.EntityFrameworkCore;

namespace ASP.NETCoreApplication.Services
{
    public class ProductService : IProduct
    {
        private readonly AppDbContext _context;
        public ProductService(AppDbContext context)
        {
            _context = context;
        }
        public async Task<Product> AddProduct(Product product)
        {
            _context.Products.Add(product);
            await _context.SaveChangesAsync();
            return product;
        }

        public async Task<bool> DeleteProduct(int Id)
        {
            var existingProduct = await _context.Products.FindAsync(Id);
            if (existingProduct == null)
            {
                return false;

            }

            _context.Products.Remove(existingProduct);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<Product>> GetAllProduct()
        {
            return await _context.Products.ToListAsync();

        }

        public async Task<Product?> GetProductById(int Id) 
        {
            return await _context.Products.FirstOrDefaultAsync(p => p.Id == Id);  
        }

        public async Task<Product?> UpdateProduct(int Id, Product product)
        {
            var existingProduct = await _context.Products.FindAsync(Id);

            if (existingProduct == null)
            {
                return null;
            }

            existingProduct.ProductName = product.ProductName;
            existingProduct.ProductCategory = product.ProductCategory;
            existingProduct.Price = product.Price;
            existingProduct.IsActive = product.IsActive;

            await _context.SaveChangesAsync();
            return existingProduct;


        }

       

        

        public async Task<Product?> PartialUpdate(int Id, Product product )
        {
            return await UpdateProduct(Id, product);
        }
    }
}
