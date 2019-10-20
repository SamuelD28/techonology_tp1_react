using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using technology_tp1.Models;
using Technology_Tp1_React.General;
using Technology_Tp1_React.General.CrudController;
using Technology_Tp1_React.General.Repository;
using Technology_Tp1_React.Models;
using static Technology_Tp1_React.General.Cookies.CookiesExt;

namespace technology_tp1.Controllers
{
    [Route("api/orders")]
    public class OrderController : CrudController<Order>
    {
        public const string FormNameIdItem = "itemId";
        public const string FormNameQuantity = "quantity";
        public IEnumerable<MenuItem> MenuItems { get; }

        public OrderController(IRepository<Order> repository)
            : base(repository) { }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                IEnumerable<Order> ordersItems = Repository
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

        // !This method will be extracted to the client controller later on
        [HttpGet("client/orders")]
        public IActionResult GetClientOrder()
        {
            try
            {
                string clientId = Request.Cookies.Get("client-id");
                int clientIdParsed;

                if (clientId is null || !int.TryParse(clientId, out clientIdParsed))
                {
                    Response.Cookies.Set("client-id", "unknown", 60);
                    return ErrorResponse.NoMatchingDocument(-1);
                }

                Order order = Repository.Where(o => o.ClientId == clientIdParsed && !o.IsOrdered);
                return CreateValidResponse(order, StatusCodes.Status200OK);
            }
            catch (Exception e)
            {
                return ErrorResponse.InternalServerError(e.Message);
            }
        }

        [HttpPost]
        public IActionResult Post([FromBody] Order order)
            => base.CreateRecord(order);

        [HttpPost("add/{orderId}")]
        public IActionResult AddItemToOrder(int orderId, [FromBody] OrdersItems ordersItems)
        {
            try
            {
                if(orderId != ordersItems.OrderId)
                {
                    return ErrorResponse.MismatchIdentifier(ordersItems.OrderId, orderId);
                }

                if (!ModelState.IsValid)
                {
                    return ErrorResponse.WrongData();
                }

                if(!Repository.Contains(o => o.Id == orderId))
                {
                    return ErrorResponse.NoMatchingDocument(orderId);
                }

                Order order = Repository.GetById(orderId);
                order.AddItem(ordersItems);
                Repository.Update(order);
                Repository.SaveChanges();
                return CreateValidResponse(order, StatusCodes.Status201Created);
            }
            catch (Exception e)
            {
                return ErrorResponse.InternalServerError(e.Message);
            }
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] Order order)
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
