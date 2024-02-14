using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using DepotMerch.Interfaces;
using DepotMerch.Data.Products;

namespace DepotMerch.Controllers
{
    [Route("api/[controller]")]
    [ApiController] 
    public class ProductController : ControllerBase
    {
        private readonly IProduct _Product;
        public ProductController(IProduct Product)
        {
            _Product = Product;
        }

        [HttpGet]
        public async Task<List<Product>> Get()
        {
            return await Task.FromResult(_Product.GetAllProducts());
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var product = _Product.GetProduct(id);
            if (product != null)
            {
                return Ok(product);
            }
            return NotFound("The Product record couldn't be found.");
        }

        [HttpPost]
        public void Post(Product product)
        {
            _Product.AddProduct(product);
        }

        [HttpPut]
        public void Put(Product product)
        {
            _Product.UpdateProduct(product);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _Product.DeleteProduct(id);
            return Ok("Product deleted");
        }
    }
}
