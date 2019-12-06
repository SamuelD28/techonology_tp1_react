using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using technology_tp1.Models;
using Technology_Tp1_React.General.CrudController;
using Technology_Tp1_React.General.Middleware;
using Technology_Tp1_React.General.Repository;

namespace technology_tp1.Controllers
{
    [Route("api/menuitems")]
    public class MenuItemsController : CrudController<MenuItem>
    {
        public Authenticate Authenticate { get; set; }

        public MenuItemsController(IRepository<MenuItem> repository, Authenticate authenticate)
            : base(repository)
        {
            Authenticate = authenticate;
        }

        [HttpGet]
        public IActionResult Get(int? start = null, int? end = null)
            => base.GetAllRecord(start, end);

        [HttpGet("{id}")]
        public IActionResult Get(int id)
            => base.GetRecordById(id);

        [HttpPost]
        public IActionResult Post([FromBody] MenuItem menuItem)
        {
            return Authenticate.Apply(HttpContext, "Administrator", () => base.CreateRecord(menuItem));
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] MenuItem menuItem)
        {
            return Authenticate.Apply(HttpContext, "Administrator", () => base.UpdateRecord(id, menuItem));
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            return Authenticate.Apply(HttpContext, "Administrator", () => base.DeleteRecord(id));
        }
    }
}
