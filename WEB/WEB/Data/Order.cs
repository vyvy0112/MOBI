using System;
using System.Collections.Generic;

namespace WEB.Data;

public partial class Order
{
    public int OrderId { get; set; }

    public int? UserId { get; set; }

    public int? ProductId { get; set; }

    public string UserName { get; set; } = null!;

    public string ProductName { get; set; } = null!;

    public string Adrress { get; set; } = null!;

    public double Price { get; set; }

    public int Quantity { get; set; }

    public decimal? TotalPrice { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? DeliveryDate { get; set; }

    public string? OrderStatus { get; set; }

    public virtual ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();

    public virtual Product? Product { get; set; }

    public virtual User? User { get; set; }
}
