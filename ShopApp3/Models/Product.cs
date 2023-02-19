using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ShopApp3.Models;

public partial class Product
{
    [Key]
    public int Id { get; set; }

    public string ProductName { get; set; } = null!;

    public int CategoryId { get; set; }

    public int ProducerId { get; set; }

    public short AvailablePieces { get; set; }

    public decimal NetCatalogPrice { get; set; }

    public decimal NetSellingPrice { get; set; }

    public decimal NetSellingWarehouse { get; set; }

    public byte VatRate { get; set; }

    public virtual ProductCategory Category { get; set; } = null!;

    public virtual ICollection<OrderedProduct> OrderedProducts { get; } = new List<OrderedProduct>();

    public virtual Producer Producer { get; set; } = null!;
}
