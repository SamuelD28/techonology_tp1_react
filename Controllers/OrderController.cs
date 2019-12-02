﻿using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Stripe;
using technology_tp1.Models;
using Technology_Tp1_React.General;
using Technology_Tp1_React.General.CrudController;
using Technology_Tp1_React.General.Repository;
using Technology_Tp1_React.Models;
using static Technology_Tp1_React.General.Cookies.CookiesExt;

namespace technology_tp1.Controllers
{
    [Route("api/orders")]
    public class OrderController : CrudController<AnonymousOrder>
    {
        public const string FormNameIdItem = "itemId";
        public const string FormNameQuantity = "quantity";
        private readonly AppDbContext dbContext;
        private readonly IConfiguration configuration;

        public IEnumerable<MenuItem> MenuItems { get; }

        public OrderController(IRepository<AnonymousOrder> repository, AppDbContext dbContext, IConfiguration configuration)
            : base(repository)
        {
            this.dbContext = dbContext;
            this.configuration = configuration;
        }

        [HttpGet]
        public IActionResult Get(int? start = null, int? end = null)
        {
            try
            {
                if (start.HasValue && end.HasValue)
                {
                    PaginatedRequestResult<AnonymousOrder> ordersItemsPaginated = base.CreatePaginatedRequestResult(start.Value, end.Value);
                    ordersItemsPaginated.data.Include(o => o.OrdersItems);
                    return CreateValidResponse(ordersItemsPaginated, StatusCodes.Status200OK);
                }
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
        {
            // Set your secret key: remember to change this to your live secret key in production
            // See your keys here: https://dashboard.stripe.com/account/apikeys
            StripeConfiguration.ApiKey = configuration.GetValue<string>("Stripe:SK");

            // Token is created using Checkout or Elements!
            // Get the payment token submitted by the form:
            var token = order.StripeToken; // Using ASP.NET MVC

            var options = new ChargeCreateOptions
            {
                Amount = (long)order.GetTotalCost((id) => dbContext.MenuItems.First(m => m.Id == id)) * 100,
                Currency = "cad",
                Description = "Pizza order",
                Source = token,
            };
            var service = new ChargeService();
            Charge charge = service.Create(options);
            return base.CreateRecord(order);
        }


        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] AnonymousOrder order)
            => base.UpdateRecord(id, order);

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
            => base.DeleteRecord(id);

        [HttpGet("deliveryman/{id}")]
        public IActionResult GetDeliveryManOrders(int id)
        {

            try
            {
                IEnumerable<AnonymousOrder> deliveryManOrders = Repository.Filter(o => o.DeliveryMan.Id == id);
                return CreateValidResponse(deliveryManOrders, StatusCodes.Status200OK);
            }
            catch (Exception e)
            {
                return ErrorResponse.InternalServerError("An internal error occured");
            }
        }

    }
}
