namespace ClassBoxData
{
    using System;

    public class StartUp
    {
        public static void Main(string[] args)
        {
         
          
            try
            {
                double lenght = double.Parse(Console.ReadLine());
                double widtht = double.Parse(Console.ReadLine());
                double height = double.Parse(Console.ReadLine());
                var box = new Box(lenght, widtht, height);
                Console.WriteLine(box);
            }
            catch (ArgumentException ae)
            {

                Console.WriteLine(ae.Message);
            }

        }
    }
}
