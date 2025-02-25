namespace WEB.ViewModels
{
	public class ProductVM
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

		public string CategoryName { get; set; } = null!;

		public int? Number { get; set; }
	}



	public class ProductViewModel
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

		public string CategoryName { get; set; } = null!;

		public int? Number { get; set; }
	}
}
