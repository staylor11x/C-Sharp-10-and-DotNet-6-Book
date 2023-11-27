using Microsoft.AspNetCore.Mvc; //[BindProperty], IActionResult
using Microsoft.AspNetCore.Mvc.RazorPages;
using Packt.Shared;  //PageModel


namespace Northwind.web.Pages;

public class SuppliersModel : PageModel
{
    public IEnumerable<Supplier>? Suppliers { get; set; }
    public void OnGet()
    {
        ViewData["Title"] = "Northwind B2B - Suppliers";

        Suppliers = db.Suppliers
            .OrderBy(c => c.Country).ThenBy(c => c.CompanyName);
    }

    private NorthwindContext db;

    public SuppliersModel(NorthwindContext injectedContext)
    {
        db = injectedContext;
    }

    [BindProperty]  //this allows you to easily connect HTML elements on the web page with properties in the Supplier class
    public Supplier? Supplier { get; set; }

    public IActionResult OnPost()
    {
        if((Supplier is not null) && ModelState.IsValid)    //checks against existing validation rules
        {
            db.Suppliers.Add(Supplier);
            db.SaveChanges();
            return RedirectToPage("/suppliers");
        }
        else
        {
            return Page();  //return to the original page
        }
    }
}
