using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShopApp3.Models;

namespace ShopApp3.Controllers
{
        [Authorize]
        public class ProductsController : Controller
        {
            private readonly RtvDatabaseContext _context;

            public ProductsController(RtvDatabaseContext context)
            {
                _context = context;
            }

            // GET: Customers
            public async Task<IActionResult> Index(int id)
            {
                
                return View(await _context.Products.ToListAsync());
            }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Add(int id, int order)
        {
            var quaData = await _context.OrderedProducts.Where(data => data.OrderId == order && data.ProductId == id).ToListAsync();
            var orderedProduct = quaData.FirstOrDefault();

            if (quaData.Count > 0)
            {             
                orderedProduct.Quantity = orderedProduct.Quantity + 1;
            }
            else
            {
                orderedProduct = new OrderedProduct();
                orderedProduct.OrderId = order;
                orderedProduct.ProductId = id;
                orderedProduct.Quantity = 1;
            }

            _context.Update(orderedProduct);
            await _context.SaveChangesAsync();
            return Redirect($"/Orders/Details/{order}");
        }
    }
}
