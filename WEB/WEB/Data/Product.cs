using System;
using System.Collections.Generic;

namespace WEB.Data;

public partial class Product
{
    public int ProductId { get; set; }

    public string ProductName { get; set; } = null!;

    public int? CategoryId { get; set; }

    public double Price { get; set; }

    public double Discount { get; set; }

    public int Quantity { get; set; }

    public string? Description { get; set; }

    public string? Image { get; set; }

    public string? ShortDescription { get; set; }

    public string? Ram { get; set; }

    public string? Weight { get; set; }

    public string? Pin { get; set; }

    public virtual Category? Category { get; set; }

    public virtual ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
