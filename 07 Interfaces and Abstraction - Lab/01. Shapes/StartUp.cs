using System;

namespace Shapes
{
    public class StartUp
    {
     public   static void Main(string[] args)
        {
            double radius=double.Parse(Console.ReadLine());
            int width = int.Parse(Console.ReadLine());
            int height =int.Parse(Console.ReadLine());
            IDrawable circle = new Circle(radius);
            IDrawable rectandle=new Rectangle(width,height);
            circle.Draw();
            rectandle.Draw();
        }
    }
}
