using SpaceStation.IO.Contracts;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace SpaceStation.IO
{
    public class FileWiter : IWriter
    {
        public FileWiter()
        {
            using (StreamWriter sr = new StreamWriter("../../../output.txt", false))
            {
                sr.Write("");
            }
        }
        public void Write(string message)
        {
            using (StreamWriter sr = new StreamWriter("../../../output.txt", true))
            {
                sr.Write(message);
            }
        }

        public void WriteLine(string message)
        {
            using (StreamWriter sr = new StreamWriter("../../../output.txt", true))
            {
                sr.WriteLine(message);
            }
        }
    }
}
