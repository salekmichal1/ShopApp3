using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShopApp3.Areas.Identity.Data;
using ShopApp3.Models;
using System.Diagnostics;
using System.Text.Json;

namespace ShopApp3.Controllers
{
    [Authorize]
    public class OrdersController : Controller
    {
        private readonly RtvDatabaseContext _context;
        
        private readonly UserManager<ApplicationUser> _userManager;

        public OrdersController(RtvDatabaseContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;

        }

        // GET: Orders
        public async Task<IActionResult> Index(string id)
        {
            var order = _context.Orders.Include(order => order.Customer).Include(order => order.Employee).Include(order => order.OrderedProducts).ThenInclude(product => product.Product);

            if (!String.IsNullOrEmpty(id))
            {
                var orderSearch = _context.Orders.Include(order => order.Customer).Include(order => order.Employee).Include(order => order.OrderedProducts).ThenInclude(product => product.Product).Where(order => order.Id.Equals(Int32.Parse(id)));

                if (orderSearch.FirstOrDefault() == null)
                {
                    ViewBag.NoOrder = "Order not exist!";
                }
                return View(await orderSearch.ToListAsync());
            }

            return View(await order.ToListAsync());
        }

        // GET: Orders/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Orders == null)
            {
                return NotFound();
            }

            var order = _context.Orders.Include(order => order.Customer).Include(order => order.Employee).Include(order => order.OrderedProducts).ThenInclude(product => product.Product).ThenInclude(category => category.Category).FirstOrDefaultAsync(order => order.Id == id);

            if (order == null)
            {
                return NotFound();
            }

            return View(await order);
        }

        // POST: Orders/Sell
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Sell(int id, string payment)
        {
            var sum = 0;
            foreach (var dx in _context.OrderedProducts.Include(order => order.Product).Where(order => order.OrderId == id))
            {
                sum += dx.Quantity * Decimal.ToInt32(dx.Product.NetSellingPrice);
            }
            if (payment == null)
            {
                ViewBag.Payment = "Order not exist!";
            }
            else
            {
                if (sum == Int32.Parse(payment))
                {
                    var order = await _context.Orders.FirstOrDefaultAsync(c => c.Id == id);
                    order.WhetherTheOrderFulfilled = true;
                    _context.Update(order);
                    await _context.SaveChangesAsync();
                    //return RedirectToAction(nameof(Index));
                    return Redirect($"/Orders/Details/{id}");
                }
                
            }
            return Redirect($"/Orders/Details/{id}");

            //var order = await _context.Orders.FirstOrDefaultAsync(c => c.Id == id);
            //order.WhetherTheOrderFulfilled = true;
            //_context.Update(order);
            //await _context.SaveChangesAsync();
            //return RedirectToAction(nameof(Index));
        }

        // GET: Orders/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Orders/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(int id, [Bind("ShippingDate")] Order order)
        {

            var user = await _userManager.GetUserAsync(User);
            var userId = user.Id;
            order.CustomerId = id;
            order.InvoiceId = 1;
            order.WhetherTheOrderFulfilled = false;
            order.DateOfPlacingTheOrder = DateTime.Now;
            order.EmployeeId = 1;

                _context.Add(order);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));     
        }

        // GET: Orders/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            return Redirect($"/Customers/Edit/{id}");
        }

        public async Task<IActionResult> AddProduct(int? id)
        {
            return Redirect($"/Products/Index/{id}");
        }

        // GET: Orders/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Orders == null)
            {
                return NotFound();
            }

            var order = _context.Orders.Include(order => order.Customer).Include(order => order.Employee).Include(order => order.OrderedProducts).ThenInclude(product => product.Product).ThenInclude(category => category.Category).FirstOrDefaultAsync(order => order.Id == id);


            if (order == null)
            {
                return NotFound();
            }

            return View(await order);
        }

        // POST: Orders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Orders == null)
            {
                return Problem("Entity set 'RtvDatabaseContext.Orders'  is null.");
            }

            var orderedProducts = await _context.OrderedProducts.Where(orderedProducts => orderedProducts.OrderId == id).ToListAsync();
            if (orderedProducts != null)
            {
                _context.OrderedProducts.RemoveRange(orderedProducts);
            }

            var order = await _context.Orders.FindAsync(id);
            if (order != null)
            {
                _context.Orders.Remove(order);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OrderExists(int id)
        {
            return _context.Orders.Any(e => e.Id == id);
        }
    }
}
