using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using DepotMerch.Interfaces;
using DepotMerch.Data.Products;
using DepotMerch.Services;

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
        public IActionResult Get(string id)
        {
            var product = _Product.GetProduct(id);
            if (product != null)
            {
                return Ok(product);
            }
            return NotFound("The Product record couldn't be found.");
        }

        [HttpPost]
        public IActionResult Post(Product product)
        {
            // dont ask for id and generate random guid
            product.Id = Guid.NewGuid().ToString();
            // Check if all needed fields are filled
            if (product.Name == null || product.Description == null || product.Price < 0 )
            {
                return BadRequest("Please fill in all fields");
            }
            else if (product.ImageUrl != null && Image.CheckImage(product.ImageUrl))
            {
                return BadRequest("Image not supported");
            }
            else
            {
                _Product.AddProduct(product);
                return Ok("Product added");
            }
        }

        [HttpPut]
        public IActionResult Put(Product product)
        {
            // Check if all needed fields are filled
            if (product.Name == null || product.Description == null || product.Price < 0)
            {
                return BadRequest("Please fill in all fields");
            }
            else
            {
                _Product.UpdateProduct(product);
                return Ok("Product updated");
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            var product = _Product.GetProduct(id);
            if (product != null)
            {
                _Product.DeleteProduct(id);
                return Ok("Product deleted");
            }
            return NotFound("The Product record couldn't be found.");

        }
    }
}
