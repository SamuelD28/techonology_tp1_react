using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using technology_tp1.Models;
using Technology_Tp1_React.General;

namespace technology_tp1.Controllers
{
    [Route("api/menuitems")]
    public class MenuItemsController : CrudController<MenuItem>
    {
        public MenuItemsController(IRepository<MenuItem> repository)
            : base(repository) { }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                IEnumerable<MenuItem> menuItems = Repository.GetAll().Include(m => m.Image);
                return CreateValidResponse(menuItems, StatusCodes.Status200OK);
            }
            catch (Exception e)
            {
                return ErrorResponse.InternalServerError(e.Message);
            }
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                MenuItem menuItems = Repository.GetAll().Include(m => m.Image).First(m => m.Id == id);
                return CreateValidResponse(menuItems, StatusCodes.Status200OK);
            }
            catch (Exception e)
            {
                return ErrorResponse.InternalServerError(e.Message);
            }
        }

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
