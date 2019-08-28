using System;
using System.Collections.Generic;

namespace PizzaBox.Data.Entities
{
    public partial class PizzaToppingsRel
    {
        public int RelId { get; set; }
        public int PizzaId { get; set; }
        public int ToppingsId { get; set; }

        public virtual Pizza Pizza { get; set; }
        public virtual ToppingsDb Toppings { get; set; }
    }
}
