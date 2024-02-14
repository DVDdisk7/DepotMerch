using DepotMerch.Interfaces;
using DepotMerch.Data.Products;

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
            try
            {
                Product? product = _dbContext.Products.Find(id);
                if (product != null)
                {
                    _dbContext.Products.Remove(product);
                    _dbContext.SaveChanges();
                }
            }
            catch
            {
                throw;
            }
        }

        // Get product by id
        public Product GetProduct(string id)
        {
            try
            {
                Product? product = _dbContext.Products.Find(id);
                if (product != null)
                {
                    return product;
                } else
                {
                    throw new Exception("Product not found");
                }
            }
            catch
            {
                throw;
            }
        }
    }
}
