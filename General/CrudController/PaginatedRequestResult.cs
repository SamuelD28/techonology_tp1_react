using System.Linq;
using Technology_Tp1_React.General.Repository;

namespace Technology_Tp1_React.General.CrudController
{
    public class PaginatedRequestResult<T>
        where T : class, IEntity
    {
        public IQueryable<T> data { get; set; }
        public string nextQuery { get; set; }
        public string previousQuery { get; set; }
    }
}
