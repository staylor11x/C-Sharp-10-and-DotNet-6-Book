using Microsoft.AspNetCore.Mvc;
using Northwind.Mvc.Models;
using System.Diagnostics;
using Microsoft.AspNetCore.Authorization;
using Packt.Shared; //Northwind context
using Microsoft.EntityFrameworkCore;

namespace Northwind.Mvc.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly NorthwindContext db;

        public HomeController(ILogger<HomeController> logger, NorthwindContext injectedContext)
        {
            _logger = logger;
            db = injectedContext;
        }

        [ResponseCache(Duration = 10, Location = ResponseCacheLocation.Any)]
        public async Task<IActionResult> Index()
        {
            _logger.LogError("This is a serious error (not really)!");
            _logger.LogWarning("This is a warning!");
            _logger.LogWarning("Another warning");
            _logger.LogInformation("This is information");

            HomeIndexViewModel model = new
            (
                VisitorCount: (new Random()).Next(1, 1001),
                Categories: await db.Categories.ToListAsync(),
                Products: await db.Products.ToListAsync()
            );

            return View(model);     //pas the model to the view
        }

        public async Task<IActionResult> ProductDetail(int? id)
        {
            if(!id.HasValue)
            {
                return BadRequest("You must pass a product ID in the route, for example /Home/ProductDetail21");
            }

            Product? model = await db.Products
                .SingleOrDefaultAsync(p => p.ProductId == id);

            if(model == null)
            {
                return NotFound($"ProductId {id} not found.");
            }

            return View(model); //pass model the the view and then return the result
        }

        public async Task<IActionResult>CategoryDetail(int? id)
        {
            if (!id.HasValue)
            {
                return BadRequest("You must pass a category ID in the routte, for exmaple /Home/CategoryDetail1");
            }

            Category? model = await db.Categories
                .SingleOrDefaultAsync(c => c.CategoryId == id);

            if(model == null)
            {
                return NotFound($"ProductId {id} not found.");
            }

            return View(model); //pass the model to the view and then return the result
        }

        public IActionResult ModelBinding()
        {
            return View();  //the page with the form to submit
        }

        [HttpPost]
        public IActionResult ModelBinding(Thing thing)
        {
            //return View(thing); //show the model bound thing
            HomeModelBindingViewModel model = new(
                thing,
                !ModelState.IsValid,
                ModelState.Values
                .SelectMany(state => state.Errors)
                .Select(error => error.ErrorMessage)
                );
            return View(model);
        }

        [Route("private")]
        [Authorize(Roles ="Administrators")]
        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult ProductsThatCostMoreThan(decimal? price)
        {
            if(!price.HasValue)
            {
                return BadRequest("You must pass a product in the query string, for example, /Home/Products/ProductsThatCostMoreThan?price=50");
            }
            
            IEnumerable<Product> model = db.Products
                .Include(p => p.Category)
                .Include(p => p.Supplier)
                .Where(p => p.UnitPrice > price);

            if (!model.Any())
            {
                return NotFound($"No products cost more than {price:C}.");
            }

            ViewData["Max Price"] = price.Value.ToString("C");
            return View(model); //pass the model to the view
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
