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
using Technology_Tp1_React.General;
using Technology_Tp1_React.Models;
using static Technology_Tp1_React.General.Cookies.CookiesExt;

namespace technology_tp1.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class OrderController : CrudController<Order>
    {
        public const string FormNameIdItem = "itemId";
        public const string FormNameQuantity = "quantity";

        private ICartService _cart;
        private IHttpContextAccessor _httpContextAccessor;

        public IEnumerable<MenuItem> MenuItems { get; }

        public OrderController(IRepository<Order> repository) : base(repository)
        {}

        //public HomeController(
        //    ICartService cart, 
        //    IHttpContextAccessor httpContextAccessor)
        //{
        //    MenuItems = dbContext.MenuItems.Include(m => m.Image);
        //    _cart = cart;
        //    _httpContextAccessor = httpContextAccessor;
        //}

        public IActionResult GetClientOrder()
        {
            try
            {
                string clientId =  Request.Cookies.Get("client-id");
                int clientIdParsed;

                if(clientId is null || !int.TryParse(clientId, out clientIdParsed))
                {
                    return ErrorResponse.NoMatchingDocument(-1);
                }

                Order order = Repository.Where(o => o.ClientId == clientIdParsed && !o.IsOrdered);

                return CreateValidResponse(order, StatusCodes.Status200OK);
            }
            catch(Exception e)
            {
                return ErrorResponse.InternalServerError(e.Message);
            }
        }

        //public IActionResult AddItemToCart()
        //{
        //    var form = _httpContextAccessor.HttpContext.Request.Form;
        //    if (int.TryParse(form[FormNameIdItem], out int id) && int.TryParse(form[FormNameQuantity], out int quantity))
        //    {
        //        _cart.AddItem(id, quantity);
        //        _cart.Save();
        //    }
        //    HttpContext.Response.Redirect("/");
        //    return View("Index", this);
        //}

        //public IActionResult RemoveItemToCart()
        //{
        //    var form = _httpContextAccessor.HttpContext.Request.Form;
        //    if (int.TryParse(form[FormNameIdItem], out int id))
        //    {
        //        _cart.RemoveItem(id);
        //        _cart.Save();
        //    }
        //    HttpContext.Response.Redirect("/");
        //    return View("Cart", this);
        //}

        //public IActionResult DecreaseQuantityItem()
        //{
        //    var form = _httpContextAccessor.HttpContext.Request.Form;
        //    if (int.TryParse(form[FormNameIdItem], out int id) && int.TryParse(form[FormNameQuantity], out int quantity))
        //    {
        //        _cart.RemoveItem(id, quantity);
        //        _cart.Save();
        //    }
        //    HttpContext.Response.Redirect("/");
        //    return View("Cart", this);
        //}
    }
}
