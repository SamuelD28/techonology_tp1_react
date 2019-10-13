using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Serialization;
using Newtonsoft.Json;
using technology_tp1.Models;
using Technology_Tp1_React.General;

namespace technology_tp1.Controllers
{
    /// <summary>
    /// Controller responsible for the interaction with the model
    /// </summary>
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class DeliveryMenController : CrudController<DeliveryMan>
    {
        public DeliveryMenController(IRepository<DeliveryMan> repository) 
            : base(repository){}
    }
}
