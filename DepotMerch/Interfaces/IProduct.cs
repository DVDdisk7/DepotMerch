using DepotMerch.Data.Products;

namespace DepotMerch.Interfaces
{
    public interface IProduct
    {
        public List<Product> GetAllProducts();
        public void AddProduct(Product product);
        public void UpdateProduct(Product product);
        public void DeleteProduct(string id);
        public Product GetProduct(string id);
    }
}
