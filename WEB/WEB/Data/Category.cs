using System;
using System.Collections.Generic;

namespace WEB.Data;

public partial class Category
{
    public int CategoryId { get; set; }

    public string CategoryName { get; set; } = null!;

    public int? Number { get; set; }

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
