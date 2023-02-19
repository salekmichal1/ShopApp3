using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ShopApp3.Models;

public partial class OrderedProduct
{
    [Key]
    public int Id { get; set; }

    public int OrderId { get; set; }

    public int ProductId { get; set; }

    public int Quantity { get; set; }

    public virtual Order Order { get; set; } = null!;

    public virtual Product Product { get; set; } = null!;
}
