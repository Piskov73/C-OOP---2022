
namespace Shapes
{
    using System;
    using System.Collections.Generic;
    public class StartUp
    {
        public static void Main(string[] args)
        {
            Shape shape = null;
            List<Shape> shapes = new List<Shape>();
            shape = new Rectangle(5, 12);
            shapes.Add(shape);
            shape = new Circle(47);
            shapes.Add(shape);
            foreach (var item in shapes)
            {
                Console.WriteLine(item.CalculateArea());
                Console.WriteLine(item.CalculatePerimeter());
                Console.WriteLine(item.Draw());

                Console.WriteLine();
            }
        }
    }
}
