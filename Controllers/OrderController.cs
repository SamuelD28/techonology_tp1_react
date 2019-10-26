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
    [Route("api/orders")]
    public class OrderController : CrudController<AnonymousOrder>
    {
        public const string FormNameIdItem = "itemId";
        public const string FormNameQuantity = "quantity";
        public IEnumerable<MenuItem> MenuItems { get; }

        public OrderController(IRepository<AnonymousOrder> repository)
            : base(repository) { }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                IEnumerable<AnonymousOrder> ordersItems = Repository
                    .GetAll()
                    .Include(o => o.OrdersItems);
                return CreateValidResponse(ordersItems, StatusCodes.Status200OK);
            }
            catch (Exception e)
            {
                return ErrorResponse.InternalServerError(e.Message);
            }

        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
            => base.GetRecordById(id);

        [HttpPost]
        public IActionResult Post([FromBody] AnonymousOrder order)
            => base.CreateRecord(order);

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] AnonymousOrder order)
            => base.UpdateRecord(id, order);

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
            => base.DeleteRecord(id);

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
