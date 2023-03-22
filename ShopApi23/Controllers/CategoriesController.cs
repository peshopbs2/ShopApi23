using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShopApi23.Data;
using ShopApi23.DTO.Request;
using ShopApi23.DTO.Response;
using ShopApi23.Service;
using ShopApi23.Service.Abstractions;

namespace ShopApi23.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        // GET: api/Categories
        [HttpGet]
        public ActionResult<IEnumerable<CategoryResponseDTO>> GetCategories()
        {
            return _categoryService.GetAll();
        }

        // GET: api/Categories/5
        [HttpGet("{id}")]
        public ActionResult<CategoryResponseDTO> GetCategory(int id)
        {
            var category = _categoryService.GetCategory(id);

            if (category == null)
            {
                return NotFound();
            }

            return category;
        }

        // PUT: api/Categories/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCategory(int id, CategoryRequestDTO category) //TODO: CategoryRequestDto
        {
            await _categoryService.UpdateCategory(id, category);
            
            return NoContent();
        }

        // POST: api/Categories
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CategoryResponseDTO>> PostCategory(CategoryRequestDTO category)
        {
            int categoryId = await _categoryService.CreateCategory(category);

            return CreatedAtAction("GetCategory", new { id = categoryId }, category);
        }

        // DELETE: api/Categories/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            var deleted = await _categoryService.DeleteCategory(id);

            if (deleted == false)
            {
                return NotFound();
            }

            return NoContent();
        }

    }
}
