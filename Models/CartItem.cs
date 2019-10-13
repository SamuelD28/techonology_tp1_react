using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using technology_tp1.Models;

namespace Technology_Tp1_React.Models
{
    public struct CartItem
    {
        public MenuItem MenuItem { get; }
        public int Quantity { get; }

        public CartItem(MenuItem item, int quantity)
        {
            MenuItem = item;
            Quantity = quantity;
        }
    }
}
