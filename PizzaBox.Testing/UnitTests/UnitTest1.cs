using System;
using Xunit;
using PizzaBox.Domain.Models;
using System.Collections.Generic;

namespace PizzaBox.Testing
{
    public class UnitTest1
    {
        Location pizzaStore = new Location(
                "Pizza Place",
                "101 Pizza St",
                "Suite 1",
                "77777",
                "FlavorTown",
                "Texas");        

        [Fact]
        public void ComputePrice()
        {
            pizzaStore.AddCustomer("jgreen","1","Jarrett Green", "1", "2", "11111", "Houston", "Texas");
            pizzaStore.LoginCheck("jgreen","1");
            pizzaStore.AddCustomToOrder(1,1,new List<int>(){1,2,3});
            foreach (Orders i in pizzaStore.OrderList)
            {
                Assert.True(i.Price == 8);
            }
        }

        [Fact]
        public void ComputeOrderPrice()
        {
            pizzaStore.AddCustomer("jgreen","1","Jarrett Green", "1", "2", "11111", "Houston", "Texas");
            pizzaStore.LoginCheck("jgreen","1");
            pizzaStore.AddCustomToOrder(1,1,new List<int>(){1,2,3});
            pizzaStore.AddCustomToOrder(2,2,new List<int>(){1,2,3});
            foreach (Orders i in pizzaStore.OrderList)
            {
                Assert.True(i.Price == 18);
            }            
        }
    }
}
