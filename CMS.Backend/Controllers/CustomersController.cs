using CMS.Data;
using Microsoft.AspNetCore.Mvc;

namespace CMS.Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public CustomersController(ApplicationDbContext context)
        {
            _context = context;
        }

        // POST: api/customers/login
        [HttpPost("login")]
        public IActionResult Login([FromBody] CMS.Data.Entities.Customer customer)
        {
            // Kiểm tra Email và Password
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

            // Trả về thông tin khách hàng
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