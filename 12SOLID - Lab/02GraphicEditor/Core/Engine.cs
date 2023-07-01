
namespace GraphicEditor.Core
{
    using System.Collections.Generic;
    using GraphicEditor.Models;
    using Interfaces;
    using IO.Interfaces;
    using Models.Interfaces;
    public class Engine : IEngine
    {
        private readonly IReader reader;
        private readonly IWriter writer;
        private ICollection<IShape> shapes;
        private Engine()
        {
            this.shapes = new HashSet<IShape>();
        }
        public Engine(IReader reader, IWriter writer)
            : this()
        {
            this.reader = reader;
            this.writer = writer;
        }

        public void Run()
        {
            CompleteTask();
            Print();
        }
        private  void CompleteTask()
        {
            IShape shape;
            shape = new Circle();
            shapes.Add(shape);
            shape = new Rectangle();
            shapes.Add(shape);
            shape = new Square();
            shapes.Add(shape);
        }
        private void Print()
        {
            foreach (var item in shapes)
            {
               writer.WriteLine(item.Draw());
            }
        }
    }
}
