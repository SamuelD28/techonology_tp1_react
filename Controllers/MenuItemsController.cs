using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using technology_tp1.Models;
using Technology_Tp1_React.General.CrudController;
using Technology_Tp1_React.General.Repository;

namespace technology_tp1.Controllers
{
    [Route("api/menuitems")]
    public class MenuItemsController : CrudController<MenuItem>
    {
        public MenuItemsController(IRepository<MenuItem> repository)
            : base(repository) { }

        [HttpGet]
        public IActionResult Get(int? start = null, int? end = null)
            => base.GetAllRecord(start, end);

        [HttpGet("{id}")]
        public IActionResult Get(int id)
            => base.GetRecordById(id);

        [HttpPost]
        public IActionResult Post([FromBody] MenuItem menuItem)
            => base.CreateRecord(menuItem);

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] MenuItem menuItem)
            => base.UpdateRecord(id, menuItem);

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
            => base.DeleteRecord(id);
    }
}
