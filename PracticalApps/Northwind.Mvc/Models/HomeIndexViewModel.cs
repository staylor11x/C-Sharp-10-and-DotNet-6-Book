using Packt.Shared;

namespace Northwind.Mvc.Models;

//when naming view model classes follow the convention of {Controller}{Action}ViewModel

public record HomeIndexViewModel
(
    int VisitorCount,
    IList<Category> Categories,
    IList<Product> Products
);
