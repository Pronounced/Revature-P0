using System;
using System.Collections.Generic;

namespace PizzaBox.Data.Entities
{
    public partial class Pizza
    {
        public Pizza()
        {
            PizzaToppingsRel = new HashSet<PizzaToppingsRel>();
        }

        public int PizzaId { get; set; }
        public int CrustId { get; set; }
        public int SizeId { get; set; }
        public decimal Price { get; set; }
        public int OrdersId { get; set; }

        public virtual Crust Crust { get; set; }
        public virtual Orders Orders { get; set; }
        public virtual Size Size { get; set; }
        public virtual ICollection<PizzaToppingsRel> PizzaToppingsRel { get; set; }
    }
}
