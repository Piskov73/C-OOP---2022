﻿

namespace NeedForSpeed
{
    public class Vehicle
    {
        private const double DEFAULT_FUELE_CONSUMPTION = 1.25;	
        public Vehicle(int horsePower, double fuel)
        {
            HorsePower = horsePower;
            Fuel = fuel;                     
        }
        public int HorsePower { get; set; }
        public double Fuel { get; set; }
        public virtual double FuelConsumption => DEFAULT_FUELE_CONSUMPTION;
        public virtual void Drive(double kilometers)
        {
            double fuelLeft = Fuel - kilometers * FuelConsumption;
            if(fuelLeft>=0) Fuel=fuelLeft;                
        }

    }
}
