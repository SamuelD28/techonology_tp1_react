using System;
using System.ComponentModel.DataAnnotations.Schema;
using technology_tp1.Models;
using Technology_Tp1_React.General;

namespace Technology_Tp1_React.Models
{
    /// <summary>
    /// Class that handle the order items data model
    /// </summary>
    public class OrdersItems : IEntity
    {
        public OrdersItems()
        {
            CreatedOn = DateTime.Now;
            UpdatedOn = DateTime.Now;
        }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public int OrderId { get; set; }

        public Order Order { get; set; }

        public int MenuItemId { get; set; }

        public MenuItem MenuItem { get; set; }

        public int Quantity { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime UpdatedOn { get; set; }
    }

}
