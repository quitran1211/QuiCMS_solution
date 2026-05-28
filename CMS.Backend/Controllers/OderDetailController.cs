using CMS.Data.Entities;
using CMS.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;

namespace CMS.Backend.Controllers
{
    [Authorize]
    public class OrderDetailController : Controller
    {
        private readonly ApplicationDbContext _context;

        public OrderDetailController(ApplicationDbContext context)
        {
            _context = context;
        }

        // ================= INDEX =================
        public IActionResult Index(int id)
        {
            var data = _context.OrderDetails
                        .Include(x => x.Product)
                        .Where(x => x.OrderId == id)
                        .ToList();

            return View(data);
        }

        // ================= CREATE =================
        [HttpGet]
        public IActionResult Create()
        {
            LoadDropdowns();
            return View();
        }

        [HttpPost]
        public IActionResult Create(OrderDetail model)
        {
            if (!ModelState.IsValid)
            {
                LoadDropdowns();
                return View(model);
            }

            _context.OrderDetails.Add(model);
            _context.SaveChanges();

            return RedirectToAction("Index", new { id = model.OrderId });
        }

        public IActionResult Delete(int id)
        {
            var orderDetail = _context.OrderDetails.Find(id);

            if (orderDetail != null)
            {
                _context.OrderDetails.Remove(orderDetail);
                _context.SaveChanges();
            }

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var orderDetail = _context.OrderDetails.Find(id);

            if (orderDetail == null) return NotFound();

            LoadDropdowns();

            return View(orderDetail);
        }

        [HttpPost]
        public IActionResult Edit(OrderDetail model)
        {
            if (!ModelState.IsValid)
            {
                LoadDropdowns();
                return View(model);
            }

            _context.OrderDetails.Update(model);
            _context.SaveChanges();

            return RedirectToAction("Index", new { id = model.OrderId });
        }

        private void LoadDropdowns()
        {
            ViewBag.Orders = new SelectList(
                _context.Orders,
                "Id",
                "Id"
            );

            ViewBag.Products = new SelectList(
                _context.Products,
                "Id",
                "Name"
            );
        }
    }
}