using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineShop.Models.Products.Components
{
    public class SolidStateDrive : Component
    {
        private const double OverallPerformanceMultiplier = 1.20;
        public SolidStateDrive(int id, string manufacturer, string model, decimal price, int generation)
            : base(id, manufacturer, model, price, OverallPerformanceMultiplier, generation)
        {
        }
    }
}
