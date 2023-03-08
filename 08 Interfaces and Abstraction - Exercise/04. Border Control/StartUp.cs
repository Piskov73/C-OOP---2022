namespace BorderControl
{
    using System;
    using BorderControl.Coor;
    using BorderControl.IO;
    using BorderControl.IO.Interfaces;
    public class StartUp
    {
        public static void Main(string[] args)
        {
            IReader reader = new ConsoleReader();
            IWrite write = new ConsoleWrite();
            Engineer engineer= new Engineer(reader,write);
            engineer.Run();
            
        
        }
    }
}
