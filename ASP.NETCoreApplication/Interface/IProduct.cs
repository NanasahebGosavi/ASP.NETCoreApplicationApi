using ASP.NETCoreApplication.Entities;

namespace ASP.NETCoreApplication.Interface
{
    public interface IProduct
    {
        Task<IEnumerable<Product>> GetAllProduct();
        Task<Product> AddProduct(Product product);

        Task<Product?> UpdateProduct(int Id, Product product);
        Task<bool> DeleteProduct(int Id);
        Task<Product?> GetProductById(int Id);

        Task<Product> PartialUpdate(int Id, Product product);

    }
}
