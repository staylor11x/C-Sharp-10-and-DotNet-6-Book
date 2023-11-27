using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Packt.Shared;

namespace PacktFeatures.Pages;

public class CustomerPageModel : PageModel
{
    private NorthwindContext db;

    public CustomerPageModel(NorthwindContext injectedContext)
    {
        db = injectedContext;
    }

    public Customer Customer { get; set; } = null!;

    public async Task<IActionResult> OnGetAsync(string? id)
    {
        if (id is null)
        {
            return NotFound();
        }
    
        Customer = await db.Customers.FindAsync(id);
        Console.WriteLine(Customer.CustomerId);
        if(Customer is null)
        {
            return NotFound();
        }
    
        return Page();
    }
}
