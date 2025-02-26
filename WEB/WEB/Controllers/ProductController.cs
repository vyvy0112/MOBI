using Azure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using WEB.Data;
using WEB.ViewModels;
using X.PagedList;

namespace WEB.Controllers
{
	public class ProductController : Controller
	{

		QuanLyBanHangContext db = new QuanLyBanHangContext();

		private readonly ILogger<ProductController> _logger;
		public ProductController(ILogger<ProductController> logger)
		{
			_logger = logger;
			
		}
		public IActionResult Index(int? page) //hiển thị danh sách sản phẩm phân trang
		{
			int pageSize = 12;
			int pageNumber = page == null || page < 0 ? 1: page.Value;
			var listproducts = db.Products.AsNoTracking().OrderBy(x=>x.ProductName);
			PagedList<Product> products = new PagedList<Product>(listproducts, pageNumber, pageSize);
			if (products == null)
			{
				return NotFound();
			}
			return View(products);
		}
		


		public IActionResult ProductbyCategory(int? id, int? page) //hiển thị sản phẩm theo loại 
		{
			if (id == null || !db.Categories.Any(c => c.CategoryId == id))
			{
				return NotFound("Không tìm thấy loại sản phẩm này");
			}
			int pageSize = 12;
			int pageNumber = page == null || page < 0 ? 1 : page.Value;
			var listproducts = db.Products.AsNoTracking().Where(x=>x.CategoryId==id).OrderBy(x => x.ProductName);
			PagedList<Product> products = new PagedList<Product>(listproducts, pageNumber, pageSize);

			return View(products);

		}

		public IActionResult Detail(int? id)
		{
			//var product = db.Products.SingleOrDefault(x => x.ProductId == id);
			//return View(product);
			var product = db.Products.Include(x => x.Category)
				.SingleOrDefault(x => x.ProductId == id);



			if (product == null)
			{
				return NotFound();
			}

			var model = new ProductVM()
				{
					ProductId = product.ProductId,
					ProductName = product.ProductName,
					CategoryId = product.CategoryId,
					Price = product.Price,
					Discount = product.Discount,
					Quantity = product.Quantity,
					Description = product.Description,
					Image = product.Image,
					ShortDescription = product.ShortDescription,
					Capacity = product.Capacity,
					Weight = product.Weight,
					Pin = product.Pin,
					CategoryName = product.Category?.CategoryName //lấy tên thương hiệu
				};
			
	
			return View(model);
		}

		public IActionResult Search(string? query)
		{
			var hanghoa = db.Products.AsQueryable();
			if (query != null)
			{
				hanghoa = hanghoa.Where(p => p.ProductName.Contains(query));
			}
			var result = hanghoa.Select(p => new ProductViewModel
			{
				ProductId = p.ProductId,
				ProductName = p.ProductName,
				Price= p.Price,
				Discount = p.Discount,
				Image = p.Image,
				ShortDescription = p.ShortDescription,
				CategoryName = p.Category.CategoryName
			});
			return View(result);
		}


	}
}
