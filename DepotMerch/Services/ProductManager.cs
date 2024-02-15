using DepotMerch.Data.Products;
using DepotMerch.Interfaces;

namespace DepotMerch.Services
{
    public class ProductManager : IProduct
    {
        readonly DepotMerchProductsContext _dbContext = new();

        public ProductManager(DepotMerchProductsContext dbContext)
        {
            _dbContext = dbContext;
        }

        // Get all products
        public List<Product> GetAllProducts()
        {
            try
            {
                return _dbContext.Products.ToList();
            }
            catch
            {
                throw;
            }
        }

        // Add product
        public void AddProduct(Product product)
        {
            try
            {
                _dbContext.Products.Add(product);
                _dbContext.SaveChanges();
            }
            catch
            {
                throw;
            }
        }

        // Update product
        public void UpdateProduct(Product product)
        {
            try
            {
                _dbContext.Products.Update(product);
                _dbContext.SaveChanges();
            }
            catch
            {
                throw;
            }
        }

        // Delete product
        public void DeleteProduct(string id)
        {
            Product? product = _dbContext.Products.Find(id);
            if (product != null)
            {
                _dbContext.Products.Remove(product);
                _dbContext.SaveChanges();
            }
            else
            {
                throw new Exception("Product not found");
            }
        }

        // Get product by id
        public Product GetProduct(string id)
        {
            Product? product = _dbContext.Products.Find(id);
            if (product != null)
            {
                return product;
            }
            else
            {
                return null;
            }
        }

    }
}
