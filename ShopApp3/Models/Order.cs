using ShopApp3.Areas.Identity.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ShopApp3.Models;

public partial class Order
{
    [Key]
    public int Id { get; set; }

    public int CustomerId { get; set; }

    public DateTime DateOfPlacingTheOrder { get; set; }

    public DateTime? OrderRealizationDate { get; set; }

    public bool? WhetherTheOrderFulfilled { get; set; }

    public DateTime? ShippingDate { get; set; }

    public int EmployeeId { get; set; }

    public int InvoiceId { get; set; }

    public virtual Customer Customer { get; set; } = null!;

    public virtual Employee Employee { get; set; } = null!;

    public virtual Invoice Invoice { get; set; } = null!;

    public virtual ICollection<OrderedProduct> OrderedProducts { get; } = new List<OrderedProduct>();
}
