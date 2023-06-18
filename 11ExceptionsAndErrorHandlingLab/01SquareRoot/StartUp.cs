namespace _01SquareRoot
{
    using System;
    public class StartUp
    {
        public static void Main(string[] args)
        {
            double number = double.Parse(Console.ReadLine());
            try
            {
                SquareRoot(number);
            }
            catch (ArgumentException ae)
            {

                Console.WriteLine(ae.Message);
            }
            Console.WriteLine("Goodbye.");
        }

        static void SquareRoot(double number)
        {
            if(number < 0)
            {
                throw new ArgumentException("Invalid number.");
            }
            Console.WriteLine($"{Math.Sqrt(number)}");
        }
    }
}
