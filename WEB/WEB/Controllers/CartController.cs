﻿using Microsoft.AspNetCore.Mvc;

namespace WEB.Controllers
{
	public class CartController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
