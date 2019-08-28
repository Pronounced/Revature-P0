using System;
using System.Collections.Generic;

namespace PizzaBox.Data.Entities
{
    public partial class ToppingsDb
    {
        public ToppingsDb()
        {
            PizzaToppingsRel = new HashSet<PizzaToppingsRel>();
        }

        public int ToppingsId { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }

        public virtual ICollection<PizzaToppingsRel> PizzaToppingsRel { get; set; }
    }
}
