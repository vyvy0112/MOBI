using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using WEB.Data;
using WEB.ViewModels;

namespace WEB.Controllers
{
	public class AccountController : Controller
	{
		private readonly UserManager<AppUserVM> _userManager;
		private readonly SignInManager<AppUserVM> _signInManager;

		QuanLyBanHangContext db = new QuanLyBanHangContext();

		public AccountController(SignInManager<AppUserVM> signInManager, UserManager<AppUserVM> userManager)
		{
			_signInManager = signInManager;
			_userManager = userManager;
		}

		//[HttpGet]		
		
		//public IActionResult Login()
		//{
		//	if(HttpContext.Session.GetString("UserName") == null)
		//	{
		//		return View();
		//	}
		//	else
		//	{
		//		return RedirectToAction("Index", "Product");
		//	}
		//}

		//[HttpPost]
		//public IActionResult Login(AppUserVM user)
		//{
		//	if (HttpContext.Session.GetString("UserName") == null)
		//	{
		//		var dl = db.Users.Where(x=>x.UserName.Equals(user.UserName) && 
		//		x.Password.Equals(user.Password)).FirstOrDefault();
		//		if(dl != null)
		//		{
		//			HttpContext.Session.SetString("UserName", dl.UserName.ToString());
		//			return RedirectToAction("Index", "Product");
		//		}
		//	}
		//	return View();
		//}




		public IActionResult Login()
		{
			return View();
		}


		[HttpGet]		
		public ActionResult Register()
		{
			return View();
		}


		[HttpPost]
		public async Task<ActionResult> Register(AppUserVM user)
		{
			if (ModelState.IsValid)
			{
				AppUserVM newUser = new AppUserVM { UserName = user.UserName, Email = user.Email };
				IdentityResult result = await _userManager.CreateAsync(newUser, user.Password);
				if (result.Succeeded)
				{
					TempData["success"] = "Tạo user thành công";
					return Redirect("/account");
				}
				else
				{
					foreach (IdentityError error in result.Errors)
					{
						ModelState.AddModelError("", error.Description);
					}
					return View(user);
				}
			}
			return View(user);

		}
	}
}
