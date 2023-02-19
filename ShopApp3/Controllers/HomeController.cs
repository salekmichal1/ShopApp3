using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShopApp3.Models;
using System.Diagnostics;

namespace ShopApp3.Controllers
{
    public class HomeController : Controller
    {
        //private readonly ILogger<HomeController> _logger;
        //private readonly RtvDatabaseContext dbContext;

        //public HomeController(ILogger<HomeController> logger, RtvDatabaseContext dbContext)
        //{
        //    _logger = logger;
        //    this.dbContext = dbContext;
        //}

        //public IActionResult Index()
        //{
        //    return View();
        //}

        //public async Task<IActionResult> Login([Bind("Login, Password")] Employee employee)
        //{
        //    var user = await dbContext.Employees.FirstOrDefaultAsync(m => m.Login == employee.Login && m.Password == employee.Password);

        //    if (user == null)
        //    {
        //        ModelState.AddModelError("", "Login lub hasło nieprawidłowe");
        //    }

        //    return Redirect("../Orders");
        //}

        //[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        //public IActionResult Error()
        //{
        //    return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        //}

        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}