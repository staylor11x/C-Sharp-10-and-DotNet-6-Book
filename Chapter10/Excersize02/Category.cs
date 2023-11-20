using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using System.Xml.Serialization; // [column]


namespace Packt.Shared;

[Serializable]
public class Category
{
    //these properties map to columns in the database
    public int CategoryId { get; set; }

    [JsonPropertyName("CategoryName")]
    public string? CategoryName { get; set; }

    [Column(TypeName = "ntext")]
    public string? Description { get; set; }

    //defines a navigation property for related rows
    public virtual ICollection<Product> Products { get; set; }

    public Category()
    {
        // to enable developers to add products to a category we must initialise the navigation property to an empty collection
        Products = new HashSet<Product>();
    }
}
