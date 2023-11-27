using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Packt.Shared;


namespace Northwind.web.Pages
{
    public class CustomersModel : PageModel
    {
        public IEnumerable<Customer>? Customers { get; set; }
        public void OnGet()
        {
            ViewData["Title"] = "Northwind B2B - Customers";

            Customers = db.Customers
                .OrderBy(c => c.Country).ThenBy(c => c.CompanyName);
        }

        private NorthwindContext db;

        public CustomersModel(NorthwindContext injectedContext)
        {
            db = injectedContext;
        }
    }
}
