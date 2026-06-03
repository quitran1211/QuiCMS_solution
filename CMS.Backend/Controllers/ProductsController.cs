using Microsoft.AspNetCore.Mvc;
using CMS.Data;

namespace CMS.Backend.Controllers
{
    // 1. Định nghĩa đường dẫn để gọi API. [controller] sẽ tự lấy tên "Products"
    // Khi chạy, địa chỉ sẽ là: https://localhost:xxxx/api/products
    [Route("api/[controller]")]

    // 2. Đánh dấu đây là một API Controller để hệ thống hỗ trợ các tính năng RESTful
    [ApiController]

    // 3. API Controller phải kế thừa từ ControllerBase (thay vì Controller như MVC)
    public class ProductsController : ControllerBase
    {
        // 4. Khai báo biến kết nối Database
        private readonly ApplicationDbContext _context;

        // 5. Hàm khởi tạo (Constructor): "Tiêm" kết nối Database vào để sử dụng
        public ProductsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // 1. Chỉ định đây là phương thức GET (Dùng để lấy dữ liệu)
        [HttpGet]
        public IActionResult GetAll()
        {
            // Lấy dữ liệu từ bảng Products
            var products = _context.Products
                .OrderByDescending(p => p.Id)
                .Select(p => new
                {
                    p.Id,
                    p.Name,
                    p.Description,
                    p.Price,
                    p.StockQuantity,
                    p.ImageUrl,
                    p.CategoryProductId,
                    CategoryProductName = p.CategoryProduct.Name
                })
                .ToList();

            // Trả về kết quả cho Frontend kèm mã trạng thái 200 (Thành công)
            return Ok(products);
        }

        // 2. Định nghĩa đường dẫn có tham số: api/products/categoryproduct/{id}
        [HttpGet("categoryproduct/{categoryProductId}")]
        public IActionResult GetByCategory(int categoryProductId)
        {
            // Lọc các sản phẩm có CategoryProductId trùng với ID truyền vào từ URL
            var products = _context.Products
                .Where(p => p.CategoryProductId == categoryProductId)
                .Select(p => new
                {
                    p.Id,
                    p.Name,
                    p.Description,
                    p.Price,
                    p.StockQuantity,
                    p.ImageUrl,
                    p.CategoryProductId,
                    CategoryProductName = p.CategoryProduct.Name
                })
                .ToList();

            return Ok(products);
        }

        // 1. Định nghĩa đường dẫn nhận ID: api/products/{id}
        [HttpGet("{id}")]
        public IActionResult GetDetail(int id)
        {
            // 2. Tìm sản phẩm đầu tiên có Id khớp với tham số truyền vào
            var product = _context.Products
                .Where(p => p.Id == id)
                .Select(p => new
                {
                    p.Id,
                    p.Name,
                    p.Description,
                    p.Price,
                    p.StockQuantity,
                    p.ImageUrl,
                    p.CategoryProductId,
                    CategoryProductName = p.CategoryProduct.Name
                })
                .FirstOrDefault();

            // 3. Xử lý trường hợp không tìm thấy (ID không tồn tại)
            if (product == null)
            {
                // Trả về lỗi 404 kèm thông báo dưới dạng JSON
                return NotFound(new
                {
                    message = "Không tìm thấy sản phẩm này trong hệ thống"
                });
            }

            // 4. Trả về sản phẩm tìm thấy kèm mã 200 (Thành công)
            return Ok(product);
        }
    }
}