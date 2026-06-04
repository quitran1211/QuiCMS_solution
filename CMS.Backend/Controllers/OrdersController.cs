using CMS.Data;
using CMS.Data.Entities;
using Microsoft.AspNetCore.Mvc;

namespace CMS.Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        // Khai báo biến kết nối Database
        private readonly ApplicationDbContext _context;

        // Constructor
        public OrdersController(ApplicationDbContext context)
        {
            _context = context;
        }

        // POST: api/Orders
        [HttpPost]
        public IActionResult Create([FromBody] Order order)
        {
            // Kiểm tra khách hàng có tồn tại hay không
            var customer = _context.Customers
                .FirstOrDefault(c => c.Id == order.CustomerId);

            if (customer == null)
            {
                return NotFound(new
                {
                    message = "Không tìm thấy khách hàng"
                });
            }

            // Tạo mới Order để tránh nhận Navigation Property từ request
            var newOrder = new Order
            {
                CustomerId = order.CustomerId,
                Notes = order.Notes,
                Status = 0, // Chờ duyệt
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
            // Kiểm tra khách hàng có tồn tại hay không
            var customer = _context.Customers
                .FirstOrDefault(c => c.Id == customerId);

            if (customer == null)
            {
                return NotFound(new
                {
                    message = "Không tìm thấy khách hàng"
                });
            }

            // Lấy danh sách đơn hàng của khách hàng
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
}