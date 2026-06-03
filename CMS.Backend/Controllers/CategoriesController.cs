using CMS.Data;
using Microsoft.AspNetCore.Mvc;

namespace CMS.Backend.Controllers
{
    // 1. Định nghĩa đường dẫn để gọi API. [controller] sẽ tự lấy tên "Categories"
    // Khi chạy, địa chỉ sẽ là: https://localhost:xxxx/api/categories
    [Route("api/[controller]")]

    // 2. Đánh dấu đây là một API Controller để hệ thống hỗ trợ các tính năng RESTful
    [ApiController]

    // 3. API Controller phải kế thừa từ ControllerBase (thay vì Controller như MVC)
    public class CategoriesController : ControllerBase
    {
        // 4. Khai báo biến kết nối Database
        private readonly ApplicationDbContext _context;

        // 5. Hàm khởi tạo (Constructor): "Tiêm" kết nối Database vào để sử dụng
        public CategoriesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // 1. Chỉ định đây là phương thức GET (Dùng để lấy dữ liệu)
        [HttpGet]
        public IActionResult GetAll()
        {
            // Lấy dữ liệu từ bảng Categories
            var categories = _context.Categories
                .OrderByDescending(c => c.Id)
                .Select(c => new
                {
                    c.Id,
                    c.Name,
                    c.Description
                })
                .ToList();

            // Trả về kết quả cho Frontend kèm mã trạng thái 200 (Thành công)
            return Ok(categories);
        }
    }
}