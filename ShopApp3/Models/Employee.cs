using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;


namespace ShopApp3.Models;

public partial class Employee
{
    public int Id { get; set; }

    public string EmployeeName { get; set; } = null!;

    public string EmployeeSurname { get; set; } = null!;

    public string Mail { get; set; } = null!;

    public string Login { get; set; } = null!;

    public string Password { get; set; } = null!;

    public decimal? EmployeeBonus { get; set; }

    public virtual ICollection<Order> Orders { get; } = new List<Order>();
}
