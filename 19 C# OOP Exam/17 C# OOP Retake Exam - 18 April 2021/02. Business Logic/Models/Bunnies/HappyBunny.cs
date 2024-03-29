﻿namespace Easter.Models.Bunnies
{
    public class HappyBunny : Bunny
    {
        private const int ENERGY = 100;
        public HappyBunny(string name) 
            : base(name, ENERGY)
        {
        }

        public override void Work()
        {
            base.Energy -= 10;
        }
    }
}
