using CMS.Data;
using CMS.Data.Entities;
using Microsoft.AspNetCore.Mvc;

namespace CMS.Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public AuthController(ApplicationDbContext context)
        {
            _context = context;
        }

        // POST: api/Auth/CustomerRegister
        [HttpPost("CustomerRegister")]
        public IActionResult CustomerRegister([FromBody] Customer customer)
        {
            // Kiểm tra email đã tồn tại chưa
            var exists = _context.Customers
                .Any(c => c.Email == customer.Email);

            if (exists)
            {
                return BadRequest(new
                {
                    message = "Email đã tồn tại trong hệ thống"
                });
            }

            // Lưu khách hàng mới
            var newCustomer = new Customer
            {
                FullName = customer.FullName,
                Email = customer.Email,
                Password = customer.Password, // Lưu mật khẩu thô
                Phone = customer.Phone,
                Address = customer.Address
            };

            _context.Customers.Add(newCustomer);
            _context.SaveChanges();

            return Ok(new
            {
                message = "Đăng ký tài khoản thành công",
                newCustomer.Id,
                newCustomer.FullName,
                newCustomer.Email
            });
        }

        // POST: api/Auth/CustomerLogin
        [HttpPost("CustomerLogin")]
        public IActionResult CustomerLogin([FromBody] Customer customer)
        {
            var loginCustomer = _context.Customers
                .FirstOrDefault(c =>
                    c.Email == customer.Email &&
                    c.Password == customer.Password);

            if (loginCustomer == null)
            {
                return Unauthorized(new
                {
                    message = "Email hoặc mật khẩu không chính xác"
                });
            }

            return Ok(new
            {
                loginCustomer.Id,
                loginCustomer.FullName,
                loginCustomer.Email,
                loginCustomer.Phone,
                loginCustomer.Address
            });
        }
    }
}