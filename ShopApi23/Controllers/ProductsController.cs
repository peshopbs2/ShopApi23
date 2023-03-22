using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using ShopApi23.Data;
using ShopApi23.DTO.Request;
using ShopApi23.DTO.Response;
using ShopApi23.Service.Abstractions;

namespace ShopApi23.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        // GET: api/Products
        [HttpGet]
        public ActionResult<IEnumerable<ProductResponseDTO>> GetProducts()
        {
            
            return _productService.GetAll();
        }

        // GET: api/Products/5
        [HttpGet("{id}")]
        public ActionResult<ProductResponseDTO> GetProduct(int id)
        {
            var product = _productService.GetProduct(id);

            if (product == null)
            {
                return NotFound();
            }

            return product;
        }

        // PUT: api/Products/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProduct(int id, ProductRequestDTO product)
        {
            await _productService.UpdateProduct(id, product);

            return NoContent();
        }

        // POST: api/Products
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ProductResponseDTO>> PostProduct(ProductRequestDTO product)
        {
            int productId = await _productService.CreateProduct(product);

            return CreatedAtAction("GetProduct", new { id = productId }, product);
        }

        // DELETE: api/Products/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var deleted = await _productService.DeleteProduct(id);
            if (deleted == false)
            {
                return NotFound();
            }
            return NoContent();
        }

    }
}
