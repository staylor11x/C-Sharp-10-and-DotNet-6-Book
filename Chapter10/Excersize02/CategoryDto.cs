using Packt.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Packt.Shared;

[XmlRoot("Category")]
[Serializable]
public class CategoryDto
{
    [XmlElement]
    public string CategoryName { get; set; }

    [XmlElement]
    public int CategoryID { get; set; }

    [XmlElement]
    public string Description { get; set; }

    [XmlElement]
    public List<ProductDto> Products { get; set; }
}
    
