using Azure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
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
		public IActionResult Index(int? page)
		{
			int pageSize = 12;
			int pageNumber = page == null || page < 0 ? 1: page.Value;
			var listproducts = db.Products.AsNoTracking().OrderBy(x=>x.ProductName);
			PagedList<Product> products = new PagedList<Product>(listproducts, pageNumber, pageSize);
			return View(products);
		}
		


		public IActionResult ProductbyCategory(int? id, int? page)
		{
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
					Ram = product.Ram,
					Weight = product.Weight,
					Pin = product.Pin,
					CategoryName = product.Category?.CategoryName
				};
			
	
			return View(model);
		}


	}
}
