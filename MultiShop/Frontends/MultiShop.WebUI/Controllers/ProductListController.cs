﻿using Microsoft.AspNetCore.Mvc;

namespace MultiShop.WebUI.Controllers
{
    public class ProductListController : Controller
    {
        public IActionResult Index(string id)
        {   
            ViewBag.vbCategoryId = id;
            return View();
        }

        public IActionResult ProductDetail()
        {
            return View();
        }
    }
}
