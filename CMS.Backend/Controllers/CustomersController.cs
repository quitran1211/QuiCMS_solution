using CMS.Data;
using CMS.Data.Entities;
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

        // GET: api/Customers/{id}
        [HttpGet("{id}")]
        public IActionResult GetDetail(int id)
        {
            var customer = _context.Customers
                .Where(c => c.Id == id)
                .Select(c => new
                {
                    c.Id,
                    c.FullName,
                    c.Email,
                    c.Phone,
                    c.Address
                })
                .FirstOrDefault();

            if (customer == null)
            {
                return NotFound(new
                {
                    message = "Không tìm thấy khách hàng"
                });
            }

            return Ok(customer);
        }

        // PUT: api/Customers/{id}
        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] Customer customer)
        {
            var existingCustomer = _context.Customers
                .FirstOrDefault(c => c.Id == id);

            if (existingCustomer == null)
            {
                return NotFound(new
                {
                    message = "Không tìm thấy khách hàng"
                });
            }

            existingCustomer.FullName = customer.FullName;
            existingCustomer.Email = customer.Email;
            existingCustomer.Phone = customer.Phone;
            existingCustomer.Address = customer.Address;

            // Chỉ cập nhật mật khẩu khi có truyền lên
            if (!string.IsNullOrEmpty(customer.Password))
            {
                existingCustomer.Password = customer.Password;
            }

            _context.SaveChanges();

            return Ok(new
            {
                message = "Cập nhật thông tin thành công",
                existingCustomer.Id,
                existingCustomer.FullName,
                existingCustomer.Email,
                existingCustomer.Phone,
                existingCustomer.Address
            });
        }
    }
}