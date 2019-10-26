using Microsoft.AspNetCore.Mvc;
using technology_tp1.Models;
using Technology_Tp1_React.General.CrudController;
using Technology_Tp1_React.General.Repository;

namespace technology_tp1.Controllers
{
    /// <summary>
    /// Controller responsible for the interaction with the model
    /// </summary>
    [Route("api/deliverymen")]
    public class DeliveryMenController : CrudController<DeliveryMan>
    {
        public DeliveryMenController(IRepository<DeliveryMan> repository) 
            : base(repository){
        }

        [HttpGet]
        public IActionResult Get(int? start = null, int? end = null)
            => base.GetAllRecord(start, end);

        [HttpGet("{id}")]
        public IActionResult Get(int id)
            => base.GetRecordById(id);

        [HttpPost]
        public IActionResult Post([FromBody] DeliveryMan deliveryMan)
            => base.CreateRecord(deliveryMan);

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] DeliveryMan deliveryMan)
            => base.UpdateRecord(id, deliveryMan);

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
            => base.DeleteRecord(id);
    }
}
