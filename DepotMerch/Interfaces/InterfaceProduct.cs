using DepotMerch.Data.Products;

namespace DepotMerch.Interfaces
{
    public interface InterfaceProduct
    {
        public List<Product> GetAllProducts();
        public void AddProduct(Product product);
        public void UpdateProduct(Product product);
        public void DeleteProduct(int id);
        public Product GetProduct(int id);
    }
}
