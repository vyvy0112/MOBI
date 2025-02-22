using Microsoft.AspNetCore.Mvc;
using WEB.Reponsitory;

namespace WEB.ViewComponents
{
	public class MenuCategoryViewComponent:ViewComponent
	{


		//lấy từ repository của ICategoryProduct
		private readonly ICategotyProductRepository _categoryProduct;

		public MenuCategoryViewComponent(ICategotyProductRepository categoryProduct)
		{
			_categoryProduct = categoryProduct;
		}


		public IViewComponentResult Invoke()
		{
			var categories = _categoryProduct.GetAllCategories().OrderBy(x=>x.CategoryName);
			return View(categories);
		}



	}
}
