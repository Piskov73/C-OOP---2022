﻿using System;
using System.Collections.Generic;
using System.Text;

namespace AquaShop.Models.Aquariums
{
    public class SaltwaterAquarium : Aquarium
    {
        private const int Capacity = 25;
        public SaltwaterAquarium(string name)
            : base(name, Capacity)
        {
        }
    }
}
