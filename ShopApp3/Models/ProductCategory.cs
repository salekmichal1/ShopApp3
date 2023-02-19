﻿using System;
using System.Collections.Generic;

namespace ShopApp3.Models;

public partial class ProductCategory
{
    public int Id { get; set; }

    public string CategoryName { get; set; } = null!;

    public virtual ICollection<Product> Products { get; } = new List<Product>();
}
