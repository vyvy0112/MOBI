using System.Drawing;

namespace WEB.ViewModels
{
	public class CartVM
	{
		public int OrderId { get; set; }

		public int? UserId { get; set; }

		public int? ProductId { get; set; }

		public string UserName { get; set; } = null!;

		public string ProductName { get; set; } = null!;

		public string Adrress { get; set; } = null!;

		public double Price { get; set; } // giá 

		public int Quantity { get; set; } //số lượng đặt hàng 
		public string? Image { get; set; } //lấy bên productvm

		public decimal? TotalPrice
		{
			get { return (decimal?)(Quantity * Price); }
		} //tổng tiền


		//đặt hàng thì tạo ra
		//ngược lại thì không 
		public CartVM()
		{
		}
		public CartVM(ProductVM product)
		{
			ProductId = product.ProductId; //thêm sp vào giỏ hàng thì nó so sánh id với product
			ProductName = product.ProductName;
			Price = product.Price;
			Quantity = 1;
			Image = product.Image;
		}


		public DateTime? CreatedAt { get; set; }

		public DateTime? DeliveryDate { get; set; }

		public string? OrderStatus { get; set; }

	}
}
