using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Technology_Tp1_React.General
{
    public interface IEntity
    {
        DateTime CreatedOn { get; set; }
        DateTime UpdatedOn { get; set; }
        int Id { get; set; }
    }
}
