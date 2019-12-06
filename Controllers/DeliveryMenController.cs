using Microsoft.AspNetCore.Mvc;
using System.Linq;
using technology_tp1.Models;
using Technology_Tp1_React.General.CrudController;
using Technology_Tp1_React.General.Middleware;
using Technology_Tp1_React.General.Repository;
using Technology_Tp1_React.Models;

namespace technology_tp1.Controllers
{
	/// <summary>
	/// Controller responsible for the interaction with the model
	/// </summary>
	[Route("api/deliverymen")]
	public class DeliveryMenController : CrudController<DeliveryMan>
	{
		public Authenticate Authenticate { get; set; }
		private AppDbContext Context { get; }

		public DeliveryMenController(IRepository<DeliveryMan> repository, Authenticate authenticate, AppDbContext context)
			: base(repository)
		{
            Context = context;
            Authenticate = authenticate;
		}

		[HttpGet]
		public IActionResult Get(int? start = null, int? end = null)
		{
			return Authenticate.Apply(HttpContext, () => base.GetAllRecord(start, end));
		}

		[HttpGet("{id}")]
		public IActionResult Get(int id)
		{
			return Authenticate.Apply(HttpContext, () => base.GetRecordById(id));
		}

		[HttpPost]
		public IActionResult Post([FromBody] DeliveryMan deliveryMan)
		{
			return Authenticate.Apply(HttpContext, () => base.CreateRecord(deliveryMan));
		}

		[HttpPut("{id}")]
		public IActionResult Update(int id, [FromBody] DeliveryMan deliveryMan)
		{
			return Authenticate.Apply(HttpContext, () => base.UpdateRecord(id, deliveryMan));
		}

		[HttpDelete("{id}")]
		public IActionResult Delete(int id)
		{
			return Authenticate.Apply(HttpContext, () => base.DeleteRecord(id));
		}

        [HttpGet("orders")]
        public IActionResult GetOrders(int id)
        {
            return Authenticate.Apply(HttpContext, () =>
            {
                User currentUser = (User)HttpContext.Items["user"];
                //JsonResult json = Json(Context.Orders.Where(d => d.DeliveryManId == currentUser.Id));
                //json.ContentType = "application/json";
                //json.StatusCode = statusCode;
                return null;
            });
        }
    }
}
