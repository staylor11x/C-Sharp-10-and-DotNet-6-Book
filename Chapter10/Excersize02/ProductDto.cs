using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations; //[required] [StringLength]
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using System.Xml.Serialization; //[Column]

namespace Packt.Shared;

[XmlRoot("Product")]
[Serializable]
public class ProductDto
{
    [XmlElement]
    public int ProductId { get; set; }

    [XmlElement]
    public string ProductName { get; set; } = null!;

    [XmlElement]
    public decimal? Cost { get; set; }  

    [XmlElement]
    public short? Stock { get; set; }

    [XmlElement]
    public bool Discontinued { get; set; }

    // these two define the foreign key relationship to the categories table
    [XmlElement]
    public int CategoryId { get; set; }

    [XmlIgnore]
    public virtual Category Category { get; set; } = null!;
}
