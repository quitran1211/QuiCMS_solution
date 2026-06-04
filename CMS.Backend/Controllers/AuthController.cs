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
        public IActionResult CustomerRegister([FromBody] CustomerRegister model)
        {
            var exists = _context.Customers
                .Any(c => c.Email == model.Email);

            if (exists)
            {
                return BadRequest(new
                {
                    message = "Email đã tồn tại trong hệ thống"
                });
            }

            var customer = new Customer
            {
                FullName = model.FullName,
                Email = model.Email,
                Password = model.Password,
                Phone = model.Phone,
                Address = model.Address
            };

            _context.Customers.Add(customer);
            _context.SaveChanges();

            return Ok(new
            {
                message = "Đăng ký tài khoản thành công",
                customer.Id,
                customer.FullName,
                customer.Email
            });
        }

        // POST: api/Auth/CustomerLogin
        [HttpPost("CustomerLogin")]
        public IActionResult CustomerLogin([FromBody] CustomerLogin model)
        {
            var customer = _context.Customers
                .FirstOrDefault(c =>
                    c.Email == model.Email &&
                    c.Password == model.Password);

            if (customer == null)
            {
                return Unauthorized(new
                {
                    message = "Email hoặc mật khẩu không chính xác"
                });
            }

            return Ok(new
            {
                customer.Id,
                customer.FullName,
                customer.Email,
                customer.Phone,
                customer.Address
            });
        }
    }

    // DTO Đăng ký
    public class CustomerRegister
    {
        public string FullName { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public string? Phone { get; set; }

        public string? Address { get; set; }
    }

    // DTO Đăng nhập
    public class CustomerLogin
    {
        public string Email { get; set; }

        public string Password { get; set; }
    }
}