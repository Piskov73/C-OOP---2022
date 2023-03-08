using BirthdayCelebrations.Coor;
using BirthdayCelebrations.Coor.Interface;
using BirthdayCelebrations.IO;
using BirthdayCelebrations.IO.Interfaces;
using System;

namespace BirthdayCelebrations
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            IRead read = new ConsolReadLine();
            IWrite write = new ConsoleWrite();
            Engineer engineer= new Engineer(read,write);
            engineer.Run();
        }
    }
}
