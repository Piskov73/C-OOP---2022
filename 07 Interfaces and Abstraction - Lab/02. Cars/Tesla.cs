using System;

namespace Cars
{
    public class Tesla : IElectricCar
    {
        public Tesla(string model,string color, int batteries) 
        {
            this.Model= model;
            this.Color= color;
            this.Batteries= batteries;
        }
        public string Model { get; set; }

        public string Color { get; set; }
        public int Batteries { get; set; }


        public void Start()
        {
            Console.WriteLine("Engine start");
        }

        public void Stop()
        {
            Console.WriteLine("Breaaak!");
        }
        public override string ToString()
        {
            return $"{Color} Tesla {Model} with {Batteries} Batteries";
        }
    }
}
