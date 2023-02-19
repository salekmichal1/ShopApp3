using System;
using System.Collections.Generic;

namespace ShopApp3.Models;

public partial class Invoice
{
    public int Id { get; set; }

    public string InvoiceName { get; set; } = null!;

    public DateTime DateOfInvoice { get; set; }

    public virtual ICollection<Order> Orders { get; } = new List<Order>();
}
