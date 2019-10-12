using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Localization;
using technology_tp1.Models;
using technology_tp1.Services;

namespace technology_tp1.Controllers
{
    public class HomeController : Controller
    {
        public const string FormNameIdItem = "itemId";
        public const string FormNameQuantity = "quantity";

        private IStringLocalizer<HomeController> _localizer;
        private ICartService _cart;
        private IHttpContextAccessor _httpContextAccessor;

        public IEnumerable<MenuItem> MenuItems { get; }

        public HomeController(IStringLocalizer<HomeController> stringLocalizer, AppDbContext dbContext, ICartService cart, IHttpContextAccessor httpContextAccessor)
        {
            _localizer = stringLocalizer;
            MenuItems = dbContext.MenuItems.Include(m => m.Image);
            _cart = cart;
            _httpContextAccessor = httpContextAccessor;
        }

        public IActionResult Index()
        {
            ViewData["Welcome"] = _localizer["Welcome"];
            return View(this);
        }

        public IActionResult Cart()
        {
            return View("Cart", this);
        }

        public IActionResult AddItemToCart()
        {
            var form = _httpContextAccessor.HttpContext.Request.Form;
            if (int.TryParse(form[FormNameIdItem], out int id) && int.TryParse(form[FormNameQuantity], out int quantity))
            {
                _cart.AddItem(id, quantity);
                _cart.Save();
            }
            HttpContext.Response.Redirect("/");
            return View("Index", this);
        }

        public IActionResult RemoveItemToCart()
        {
            var form = _httpContextAccessor.HttpContext.Request.Form;
            if (int.TryParse(form[FormNameIdItem], out int id))
            {
                _cart.RemoveItem(id);
                _cart.Save();
            }
            HttpContext.Response.Redirect("/");
            return View("Cart", this);
        }

        public IActionResult DecreaseQuantityItem()
        {
            var form = _httpContextAccessor.HttpContext.Request.Form;
            if (int.TryParse(form[FormNameIdItem], out int id) && int.TryParse(form[FormNameQuantity], out int quantity))
            {
                _cart.RemoveItem(id, quantity);
                _cart.Save();
            }
            HttpContext.Response.Redirect("/");
            return View("Cart", this);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return Redirect("/");
        }
    }
}
