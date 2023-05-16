namespace Shapes
{
    using System;

    public class Circle : IDrawable
    {
        private double radius;

        public Circle(double radius)
        {
            this.radius = radius;
        }
        public void Draw()
        {
            double radius = this.radius;
            double thickness = 0.4;
            char symbol = '*';

            while (radius <= 0) ;

            double rIn = radius - thickness, rOut = radius + thickness;

            for (double y = radius; y >= -radius; --y)
            {
                for (double x = -radius; x < rOut; x += 0.5)
                {
                    double value = x * x + y * y;
                    if (value >= rIn * rIn && value <= rOut * rOut)
                    {
                        Console.Write(symbol);
                    }
                    else
                    {
                        Console.Write(" ");
                    }
                }
                Console.WriteLine();
            }
            Console.ReadKey();
        }
    }
}
