using System;
using System.Collections.Generic;

namespace ShopApp3.Models;

public partial class Producer
{
    public int Id { get; set; }

    public string ProducerName { get; set; } = null!;

    public virtual ICollection<Product> Products { get; } = new List<Product>();
}
