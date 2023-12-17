using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineShop.Models.Products.Components
{
    public class Motherboard : Component
    {
        private const double OverallPerformanceMultiplier = 1.25;
        public Motherboard(int id, string manufacturer, string model, decimal price, int generation)
            : base(id, manufacturer, model, price, OverallPerformanceMultiplier, generation)
        {
        }
    }
}
