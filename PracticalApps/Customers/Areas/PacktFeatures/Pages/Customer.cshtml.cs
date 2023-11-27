using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
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

    public List<Order> Orders { get; set; } = null!;

    public async Task<IActionResult> OnGetAsync(string? id)
    {
        if (id is null)
        {
            return NotFound();
        }
    
        Customer = await db.Customers.FindAsync(id);

        if(Customer is null)
        {
            return NotFound();
        }

        //get the customers orders

        Orders = await db.Orders.Where(o => o.CustomerId == id).ToListAsync();

        return Page();
    }
}
