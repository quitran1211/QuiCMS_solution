using CMS.Data;
using Microsoft.AspNetCore.Mvc;

namespace CMS.Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesProductsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public CategoriesProductsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/CategoriesProducts
        [HttpGet]
        public IActionResult GetAll()
        {
            var categoriesproducts = _context.CategoriesProducts
                .OrderByDescending(cp => cp.Id)
                .Select(cp => new
                {
                    cp.Id,
                    cp.Name,
                    cp.Description
                })
                .ToList();

            return Ok(categoriesproducts);
        }

        // GET: api/CategoriesProducts/{id}
        [HttpGet("{id}")]
        public IActionResult GetDetail(int id)
        {
            var category = _context.CategoriesProducts
                .Where(cp => cp.Id == id)
                .Select(cp => new
                {
                    cp.Id,
                    cp.Name,
                    cp.Description
                })
                .FirstOrDefault();

            if (category == null)
            {
                return NotFound(new
                {
                    message = "Không tìm thấy danh mục sản phẩm"
                });
            }

            return Ok(category);
        }
    }
}