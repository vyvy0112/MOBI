﻿namespace WEB.ViewModels
{
    public class CartItem
    {
		public int ProductId { get; set; }
		public string ProductName { get; set; }
		public int Quantity { get; set; }
		public decimal Price { get; set; }
		public decimal Total => Quantity * Price;

		public string Image { get; set; }
	}
}
