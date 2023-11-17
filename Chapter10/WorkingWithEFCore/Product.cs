﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations; //[required] [StringLength]
using System.ComponentModel.DataAnnotations.Schema; //[Column]

namespace Packt.Shared;

public class Product
{
    public int ProductId { get; set; }

    [Required]
    [StringLength(40)]
    public string ProductName { get; set; } = null!;

    [Column("UnitPrice", TypeName = "money")]
    public decimal? Cost { get; set; }  //property name != column name

    [Column("UnitsInStock")]
    public short? Stock { get; set; }

    public bool Discontinued { get; set; }

    // these two define the foreign key relationship to the categories table
    public int CategoryId { get; set; }
    public virtual Category Category { get; set; } = null!;
}
