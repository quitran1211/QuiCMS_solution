using CMS.Data;
using CMS.Data.Entities;
using Microsoft.AspNetCore.Mvc;

namespace CMS.Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public OrdersController(ApplicationDbContext context)
        {
            _context = context;
        }

        // POST: api/Orders
        [HttpPost]
        public IActionResult Create([FromBody] CreateOrderRequest model)
        {
            var customer = _context.Customers
                .FirstOrDefault(c => c.Id == model.CustomerId);

            if (customer == null)
            {
                return NotFound(new
                {
                    message = "Không tìm thấy khách hàng"
                });
            }

            var newOrder = new Order
            {
                CustomerId = model.CustomerId,
                Notes = model.Notes,
                Status = 0,
                OrderDate = DateTime.Now
            };

            _context.Orders.Add(newOrder);
            _context.SaveChanges();

            return Ok(new
            {
                message = "Tạo đơn hàng thành công",
                newOrder.Id,
                newOrder.OrderDate,
                newOrder.CustomerId,
                newOrder.Status,
                newOrder.Notes
            });
        }

        // GET: api/Orders/{id}
        [HttpGet("{id}")]
        public IActionResult GetDetail(int id)
        {
            var order = _context.Orders
                .Where(o => o.Id == id)
                .Select(o => new
                {
                    o.Id,
                    o.OrderDate,
                    o.CustomerId,
                    CustomerName = o.Customer.FullName,
                    o.Status,
                    o.Notes
                })
                .FirstOrDefault();

            if (order == null)
            {
                return NotFound(new
                {
                    message = "Không tìm thấy đơn hàng"
                });
            }

            return Ok(order);
        }

        // GET: api/Orders/customer/{customerId}
        [HttpGet("customer/{customerId}")]
        public IActionResult GetByCustomer(int customerId)
        {
            var customer = _context.Customers
                .FirstOrDefault(c => c.Id == customerId);

            if (customer == null)
            {
                return NotFound(new
                {
                    message = "Không tìm thấy khách hàng"
                });
            }

            var orders = _context.Orders
                .Where(o => o.CustomerId == customerId)
                .OrderByDescending(o => o.Id)
                .Select(o => new
                {
                    o.Id,
                    o.OrderDate,
                    o.CustomerId,
                    CustomerName = o.Customer.FullName,
                    o.Status,
                    o.Notes
                })
                .ToList();

            return Ok(orders);
        }
    }

    // DTO tạo đơn hàng
    public class CreateOrderRequest
    {
        public int CustomerId { get; set; }

        public string? Notes { get; set; }
    }
}