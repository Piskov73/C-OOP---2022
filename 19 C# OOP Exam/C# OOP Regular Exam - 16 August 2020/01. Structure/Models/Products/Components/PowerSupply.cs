using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineShop.Models.Products.Components
{
    public class PowerSupply : Component
    {
        private const double OverallPerformanceMultiplier = 1.05;
        public PowerSupply(int id, string manufacturer, string model, decimal price,  int generation)
            : base(id, manufacturer, model, price, OverallPerformanceMultiplier, generation)
        {
        }
    }
}
