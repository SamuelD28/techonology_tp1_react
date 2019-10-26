using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Technology_Tp1_React.General;

namespace Technology_Tp1_React.Models
{
    /// <summary>
    /// Class that handle the order data model
    /// </summary>
    public class Order : IEntity
    {
        public Order()
        {
            CreatedOn = DateTime.Now;
            UpdatedOn = null;
            OrdersItems = new List<OrdersItems>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public bool IsOrdered { get; set; }
        public int? ClientId { get; set; }

        public string CustomerName { get; set; }

        public string CustomerAdress { get; set; }

        [Phone]
        public string CustomerPhoneNumber { get; set; }

        public ICollection<OrdersItems> OrdersItems { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime? UpdatedOn { get; set; }

        public DateTime? DeliveredAt { get; set; }

        public void AddItem(OrdersItems orderItems)
            => OrdersItems.Add(orderItems);

        public IEnumerable<CartItem> GetItems() 
            => OrdersItems?.Select(oi => new CartItem(oi.MenuItem, oi.Quantity));

        public decimal GetTotalCost() 
            => OrdersItems?.Sum(o => o.Quantity * o.MenuItem.Price) ?? 0;
    }
}
