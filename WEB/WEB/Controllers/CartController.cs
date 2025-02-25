using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WEB.Data;
using WEB.ViewModels;
using WEB.Reponsitory;


namespace WEB.Controllers
{
	public class CartController : Controller
	{
		private readonly QuanLyBanHangContext _context;

		public CartController(QuanLyBanHangContext context)
		{
			_context = context;
		}

		const string CART_KEY = "Cart";
		public List<CartItem> Cart => HttpContext.Session.Get<List<CartItem>>(CART_KEY) ?? new List<CartItem>();
			

		public IActionResult AddToCart(int id, int quantity = 1)
		{
			var giohang = Cart; //từ danh sách cart hàng hóa
			var item = giohang.SingleOrDefault(p => p.ProductId == id); //kiểm tra xem hàng hóa đã có trong giỏ hàng chưa
			if (item == null)
			{
				var product = _context.Products.SingleOrDefault(p=>p.ProductId == id); //lấy thông tin sản phẩm từ database
				if (product == null)
				{
					TempData["Message"] = $"Sản phẩm không tồn tại có mã {id}";
					return Redirect("/404");
				}
				item = new CartItem
				{
					ProductId = product.ProductId,
					ProductName = product.ProductName,
					Price = product.Price,
					Image = product.Image ?? string.Empty,
					Quantity = quantity,
				};
				giohang.Add(item);

			}
			else
			{
				item.Quantity += quantity;
			}
			HttpContext.Session.Set(CART_KEY, giohang);

			return View(Cart);
		}

		public IActionResult RemoveCart(int id)
		{
			var giohang = Cart;
			var item = giohang.SingleOrDefault(p => p.ProductId == id);
			if(item != null)
			{
				giohang.Remove(item);
				HttpContext.Session.Set(CART_KEY, giohang);
			}
			return View(AddToCart);
		}
	}
}
