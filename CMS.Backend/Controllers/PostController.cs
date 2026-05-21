using CMS.Data;
using CMS.Data.Entities;
using Microsoft.AspNetCore.Mvc;

namespace CMS.Backend.Controllers
{
    public class PostController : Controller
    {
        private readonly ApplicationDbContext _context;
        public PostController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            // Lấy dữ liệu THẬT từ bảng Posts trong SQL
            var data = _context.Posts.ToList();
            return View(data);
        }

        // Hàm Details: Hiển thị chi tiết một bài viết (Bổ sung  khá giỏi)
        public IActionResult Details(int id)
        {
            // Giả lập tìm bài viết trong Database bằng Id
            // Trong thực tế tuần sau sẽ là: _context.Posts.Find(id);
            var post = new Post
            {
                Id = id,
                Title = "Nội dung chi tiết bài viết số " + id,
                Content = "Đây là nội dung đầy đủ của bài viết mà bạn vừa click vào. Ở đây  có thể viết dài hơn để thấy sự khác biệt với trang danh sách.",
                ImageUrl = "https://via.placeholder.com/600x300", // Ảnh to hơn
                CreatedDate = DateTime.Now
            };

            if (post == null) return NotFound();

            return View(post);
        }
        // 1. Hàm GET: Dùng để hiển thị giao diện Form cho nhập
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        // 2. Hàm POST: Dùng để đón dữ liệu từ Form gửi lên và lưu vào SQL
        [HttpPost]
        public IActionResult Create(Post model)
        {
            // BƯỚC 1: Thêm dữ liệu vào bộ nhớ tạm của Entity Framework
            _context.Posts.Add(model);
            // BƯỚC 2: Ra lệnh cho hệ thống ghi dữ liệu thật sự vào SQL Server
            _context.SaveChanges();
            // Sau khi lưu thành công, tự động quay về trang danh sách
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            // Bước 1: Tìm đối tượng danh mục trong Database bằng Id
            var post = _context.Posts.Find(id);

            // Kiểm tra nếu tìm thấy thì mới xóa
            if (post != null)
            {
                // Bước 2: Lệnh xóa khỏi bộ nhớ tạm (Tracking)
                _context.Posts.Remove(post);

                // Bước 3: Chốt phiên làm việc, xóa thực sự trong SQL Server
                _context.SaveChanges();
            }

            // Sau khi xóa xong, quay lại trang danh sách để cập nhật giao diện
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            // Tìm danh mục trong Database theo Id [cite: 348, 350]
            var post = _context.Posts.Find(id);

            if (post == null) return NotFound();

            return View(post); // Gửi đối tượng tìm được sang giao diện Edit
        }

        // 2. Hàm POST: Nhận dữ liệu mới từ người dùng và lưu lại
        [HttpPost]
        public IActionResult Edit(Post model)
        {
            // Lệnh cập nhật đối tượng vào bộ nhớ tạm
            _context.Posts.Update(model);

            // Lưu thay đổi thực sự xuống SQL Server [cite: 504, 509]
            _context.SaveChanges();

            // Quay lại trang danh sách để xem kết quả
            return RedirectToAction("Index");
        }
    }

}
