using CMS.Data;
using CMS.Data.Entities;
using Microsoft.AspNetCore.Mvc;

namespace CMS.Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderDetailsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public OrderDetailsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // POST: api/OrderDetails
        [HttpPost]
        public IActionResult Create([FromBody] CreateOrderDetailRequest model)
        {
            // Kiểm tra đơn hàng
            var order = _context.Orders
                .FirstOrDefault(o => o.Id == model.OrderId);

            if (order == null)
            {
                return NotFound(new
                {
                    message = "Không tìm thấy đơn hàng"
                });
            }

            // Kiểm tra sản phẩm
            var product = _context.Products
                .FirstOrDefault(p => p.Id == model.ProductId);

            if (product == null)
            {
                return NotFound(new
                {
                    message = "Không tìm thấy sản phẩm"
                });
            }

            var newOrderDetail = new OrderDetail
            {
                OrderId = model.OrderId,
                ProductId = model.ProductId,
                Quantity = model.Quantity,
                UnitPrice = product.Price
            };

            _context.OrderDetails.Add(newOrderDetail);
            _context.SaveChanges();

            return Ok(new
            {
                message = "Thêm sản phẩm vào đơn hàng thành công",
                newOrderDetail.Id,
                newOrderDetail.OrderId,
                newOrderDetail.ProductId,
                newOrderDetail.Quantity,
                newOrderDetail.UnitPrice
            });
        }

        // GET: api/OrderDetails/order/{orderId}
        [HttpGet("order/{orderId}")]
        public IActionResult GetByOrder(int orderId)
        {
            var order = _context.Orders
                .FirstOrDefault(o => o.Id == orderId);

            if (order == null)
            {
                return NotFound(new
                {
                    message = "Không tìm thấy đơn hàng"
                });
            }

            var orderDetails = _context.OrderDetails
                .Where(od => od.OrderId == orderId)
                .Select(od => new
                {
                    od.Id,
                    od.OrderId,
                    od.ProductId,
                    ProductName = od.Product.Name,
                    od.Quantity,
                    od.UnitPrice,
                    TotalPrice = od.Quantity * od.UnitPrice
                })
                .ToList();

            return Ok(orderDetails);
        }
    }

    // DTO tạo chi tiết đơn hàng
    public class CreateOrderDetailRequest
    {
        public int OrderId { get; set; }

        public int ProductId { get; set; }

        public int Quantity { get; set; }
    }
}