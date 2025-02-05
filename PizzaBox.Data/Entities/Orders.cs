﻿using System;
using System.Collections.Generic;

namespace PizzaBox.Data.Entities
{
    public partial class Orders
    {
        public Orders()
        {
            Pizza = new HashSet<Pizza>();
        }

        public int OrdersId { get; set; }
        public string CustUserName { get; set; }
        public decimal Price { get; set; }
        public DateTime OrderTime { get; set; }

        public virtual ICollection<Pizza> Pizza { get; set; }
    }
}
