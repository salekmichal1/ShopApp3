using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ShopApp3.Models;

public partial class Customer
{
    [Key]
    public int Id { get; set; }

    public string CustomerName { get; set; } = null!;

    public string Surname { get; set; } = null!;

    public string? CompanyName { get; set; }

    public int? CompanyNumber { get; set; }

    public string Street { get; set; } = null!;

    public int StreetNumber { get; set; }

    public int? FlatNumber { get; set; }

    public string PostCode { get; set; } = null!;

    public string City { get; set; } = null!;

    [DataType(DataType.PhoneNumber)]
    [RegularExpression(@"^(\d{9})$", ErrorMessage = "Invalid phone number (Should contains 9 digits)")]
    public string PhoneNumber { get; set; } = null!;

    [Required(ErrorMessage = "The Mail field is required.")]
    [RegularExpression(".+\\@.+\\.[a-z]{2,3}", ErrorMessage = "Invalid email address.")]
    public string Mail { get; set; } = null!;

    public virtual ICollection<Order> Orders { get; } = new List<Order>();
}
