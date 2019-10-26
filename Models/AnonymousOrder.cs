using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Technology_Tp1_React.General;
using Technology_Tp1_React.General.Repository;

namespace Technology_Tp1_React.Models
{
    /// <summary>
    /// Class that handle the order data model
    /// </summary>
    public class AnonymousOrder : IEntity
    {
        const int BaseTimeScheduled = 30;

        public AnonymousOrder()
        {
            CreatedOn = DateTime.Now;
            Scheduled = CreatedOn.AddMinutes(BaseTimeScheduled);
            UpdatedOn = null;
            OrdersItems = new List<OrdersItems>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public string CustomerName { get; set; }

        [Required]
        public string CustomerAdress { get; set; }

        [Phone]
        [Required]
        public string CustomerPhoneNumber { get; set; }

        public ICollection<OrdersItems> OrdersItems { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime? UpdatedOn { get; set; }

        public DateTime? DeliveredAt { get; set; }

        /// <summary>
        /// Should be delivered at that time
        /// </summary>
        public DateTime Scheduled { get; set; }

        public IEnumerable<CartItem> GetItems() 
            => OrdersItems?.Select(oi => new CartItem(oi.MenuItem, oi.Quantity));

        public decimal GetTotalCost() 
            => OrdersItems?.Sum(o => o.Quantity * o.MenuItem.Price) ?? 0;
    }
}
